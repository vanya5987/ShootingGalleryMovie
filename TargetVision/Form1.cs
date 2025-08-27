using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using TargetVision.Angle;
using TargetVision.Configs;
using TargetVision.ContoursAnalyzer;
using TargetVision.CoordinatesHandler;
using TargetVision.DetectShape;
using TargetVision.DrawHandler;
using TargetVision.Filters;
using TargetVision.PicturesCapture;
using TargetVision.TypesContainer;
using TargetVision.UdpController;
using TargetVision.UI;
using TargetVision.Validator;

namespace TargetVision
{
    public partial class FormsController : Form
    {
        private readonly List<string> _landmarksAngles = new List<string>();
        private readonly List<string> _coordinatesLabel = new List<string>();
        private readonly List<Point> _laserPoints = new List<Point>();
        private readonly int _screenLengthCoef = 100;
        private readonly int _laserDelayCoef = 1000;
        private readonly Stopwatch _stopwatch;
        private readonly System.Windows.Forms.Timer _timer;

        private IScreenController _screenController;
        private IGetUI _getUI;
        private ICaptureImage _captureImage;
        private IApplyFilters _applyFilters;
        private ISetImageToPictureBox _setImageToPictureBox;
        private IAnalyzeContours _analyzeContours;
        private ICoordinateHandler _shapeCenterCoordinate;
        private IDraw _draw;
        private IValidate _validate;
        private IUdpSender _udpSender;
        private IAnglesSorter _anglesSorter;
        private IAngleComputer _angleComputer;
        private ITypeContainer _typeContainer;
        private IScreenElement _screenElement;

        private VideoCapture _capture;
        private volatile bool _isCapturing;
        private int _cameraId;
        private int _laserDelay;

        public FormsController()
        {
            InitializeComponent();
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 200;
        }

        private void InitializeObjects()
        {
            _typeContainer = new TypeContainer();

            TypeContainerValueInitialize();

            _analyzeContours = new AnalyzeContours();
            _anglesSorter = new AnglesSorter();
            _applyFilters = new ApplyFilters(_anglesSorter);
            _udpSender = new UdpSender();

            _getUI = new GetUI(_capture, Capture, CoordinateLabel, ShapeCountLabel, ImageResolution, UpperLeft, UpperRight, LowerRight, LowerLeft, _typeContainer);
            _draw = new Draw(_analyzeContours, _getUI);
            _validate = new Validate(_analyzeContours, _typeContainer);

            _captureImage = new CaptureImage(_getUI);
            _angleComputer = new AngleComputer(_getUI, _landmarksAngles);
            _screenElement = new ScreenElement(_getUI, _draw, _anglesSorter, _angleComputer);
            _setImageToPictureBox = new CaptureImage(_getUI);

            _shapeCenterCoordinate = new CoordinateHandler(_getUI, _udpSender, ShootChecker, _coordinatesLabel, _laserPoints, _typeContainer);
            _screenController = new ScreenController(_getUI, _applyFilters, _setImageToPictureBox, _analyzeContours, _shapeCenterCoordinate, _validate, _typeContainer, _screenElement);
        }

        private void TypeContainerValueInitialize()
        {
            _typeContainer.LowScreenThreshold = LowScreenThreshold.Value;
            _typeContainer.UppScreenThreshold = UppScreenThreshold.Value;
            _typeContainer.LowLaserThreshold = LowLaserThreshold.Value;
            _typeContainer.UppLaserThreshold = UppLaserThreshold.Value;
            _typeContainer.LowScreenContourLength = MinScreenLength.Value * _screenLengthCoef;
            _typeContainer.UppScreenContourLength = MaxScreenLength.Value * _screenLengthCoef;
            _typeContainer.LaserDelay = LaserDelay.Value * _laserDelayCoef;
        }

        private void ButtonIsClicked(EventHandler captureGrabbed, Button buttonOne, Button buttonTwo)
        {
            if (_capture == null)
                StartShowingVideo(captureGrabbed, buttonOne, buttonTwo);
            else if (_capture != null && _capture.IsOpened)
                StopShowingVideo(buttonOne, buttonTwo);
            else
                StartShowingVideo(captureGrabbed, buttonOne, buttonTwo);
        }

        private void StartShowingVideo(EventHandler captureGrabbed, Button buttonOne, Button buttonTwo)
        {
            if (_isCapturing)
                return;

            if (Menu.SelectedItem == null)
            {
                MessageBox.Show("Выберите камеру...", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShootChecker.Items.Clear();
            _capture = new VideoCapture(_cameraId);

            if (!_capture.IsOpened)
            {
                MessageBox.Show("Не удалось открыть камеру...", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupCapture();
                return;
            }

            _capture.ImageGrabbed += captureGrabbed;
            _capture.Start();
            _isCapturing = true;

            Menu.Enabled = false;
            buttonOne.Enabled = false;
            buttonTwo.Enabled = false;

            InitializeObjects();

            _timer.Tick += UpdatePerSecond;
            _timer.Start(); // запускаем таймер
        }

        private void StopShowingVideo(Button buttonOne, Button buttonTwo)
        {
            if (!_isCapturing)
                return;

            CleanupCapture();

            if (!IsDisposed && Capture?.Image != null)
                Capture.Image.Dispose();

            buttonOne.Enabled = true;
            buttonTwo.Enabled = true;
            Menu.Enabled = true;

            _timer.Tick -= UpdatePerSecond;
            _timer.Stop(); // запускаем таймер
        }

        private void CleanupCapture()
        {
            if (_capture == null)
                return;

            _isCapturing = false;

            if (_capture.IsOpened)
                _capture.Stop();

            _capture.ImageGrabbed -= CaptureGrabbedCalibrate;
            _capture.ImageGrabbed -= UpperLaserGrabbed;
            _capture.ImageGrabbed -= LowerLaserGrabbed;

            _capture.Dispose();
            _capture = null;
        }

        private bool BaseCaptureGrabbed(Button buttonOne, Button buttonTwo, Action action, bool lowerLaserMode)
        {
            if (!_isCapturing)
                return false;

            if (_screenController == null)
                return false;

            action();

            if (lowerLaserMode)
                GetLowThresholdLaser();

            return true;
        }

        private void GetLowThresholdLaser()
        {
            _laserDelay = _typeContainer.LaserDelay;

            if (!ScreenController.IsContourFind && _stopwatch.ElapsedMilliseconds >= _laserDelay && _laserPoints.Count != 0)
            {
                Point lastPoint = _laserPoints.Last();
                var lastItem = ShootChecker.Items.Cast<object>().LastOrDefault();

                if (_laserPoints != null)
                {
                    if (_coordinatesLabel.Last() != lastItem)
                    {
                        _udpSender.SendCoordinates(lastPoint.X, lastPoint.Y);
                        _getUI.LowShootUpdate();

                        if (ShootChecker.InvokeRequired)
                            ShootChecker.Invoke(new Action(() => ShootChecker.Items.Add(_coordinatesLabel.Last())));
                        else
                            ShootChecker.Items.Add(_coordinatesLabel.Last());
                    }
                    else
                        return;
                }

                _stopwatch.Restart();
            }
        }

        private void UpdatePerSecond(object sender, EventArgs e)
        {
            LaserDelayCount.Text = $"{LaserDelay.Value}";
            LowScreenThresholdCount.Text = $"{_typeContainer.LowScreenThreshold}";
            UppScreenThresholdCount.Text = $"{_typeContainer.UppScreenThreshold}";
            LowLaserThresholdCount.Text = $"{_typeContainer.LowLaserThreshold}";
            UppLaserThresholdCount.Text = $"{_typeContainer.UppLaserThreshold}";
            MinScreenLengthCount.Text = $"{_typeContainer.LowScreenContourLength}";
            MaxScreenLengthCount.Text = $"{_typeContainer.UppScreenContourLength}";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void CaptureGrabbedCalibrate(object sender, EventArgs e) => BaseCaptureGrabbed(UpperLaserThreshold, LowerLaserThreshold,
            () => _screenController.StartCalibration(GetInputImage()), false);

        private void UpperLaserGrabbed(object sender, EventArgs e) => BaseCaptureGrabbed(LowerLaserThreshold, CalibrationButton,
            () => _screenController.UpperLaserThreshold(GetInputImage(), CalibrationButton), false);

        private void LowerLaserGrabbed(object sender, EventArgs e) => BaseCaptureGrabbed(UpperLaserThreshold, CalibrationButton,
            () => _screenController.LowerLaserThreshold(GetInputImage(), CalibrationButton), true);

        public Image<Bgr, byte> GetInputImage() => _captureImage.GetCalibrateCapture().ToImage<Bgr, byte>();

        private void LoadProgram(object sender, EventArgs e) => new Cams(Menu);

        private void ChangeCameraId(object sender, EventArgs e) => _cameraId = Menu.SelectedIndex;

        private void ButtonUpperLaserClick(object sender, EventArgs e) => ButtonIsClicked(UpperLaserGrabbed, CalibrationButton, LowerLaserThreshold);

        private void CalibrationButtonClick(object sender, EventArgs e) => ButtonIsClicked(CaptureGrabbedCalibrate, UpperLaserThreshold, LowerLaserThreshold);

        private void LowerLaserThreshold_Click(object sender, EventArgs e) => ButtonIsClicked(LowerLaserGrabbed, CalibrationButton, UpperLaserThreshold);
    }
}


