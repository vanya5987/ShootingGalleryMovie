using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using TargetVision.ContoursAnalyzer;
using TargetVision.CoordinatesHandler;
using TargetVision.Filters;
using TargetVision.PicturesCapture;
using TargetVision.TypesContainer;
using TargetVision.UI;
using TargetVision.Validator;

namespace TargetVision.DetectShape
{
    internal class ScreenController : IScreenController
    {
        private readonly IGetUI _getUI;
        private readonly IApplyFilters _applyFilters;
        private readonly ISetImageToPictureBox _setImageToPictureBox;
        private readonly IAnalyzeContours _analyzeContours;
        private readonly ICoordinateHandler _shapeCenterCoordinate;
        private readonly IValidate _validate;
        private readonly ITypeContainer _typeContainer;
        private readonly IScreenElement _screenElement;

        private readonly List<Point> _screenPoints = new List<Point>();

        public static bool IsContourFind = false;

        public ScreenController(IGetUI getUI, IApplyFilters applyFilters, ISetImageToPictureBox setImageToPictureBox, IAnalyzeContours analyzeContours,
            ICoordinateHandler shapeCenterCoordinate, IValidate validate, ITypeContainer typeContainer, IScreenElement screenElement)
        {
            _getUI = getUI ?? throw new ArgumentNullException(nameof(_getUI));
            _applyFilters = applyFilters ?? throw new ArgumentNullException(nameof(_applyFilters));
            _setImageToPictureBox = setImageToPictureBox ?? throw new ArgumentNullException(nameof(_setImageToPictureBox));
            _analyzeContours = analyzeContours ?? throw new ArgumentNullException(nameof(_analyzeContours));
            _shapeCenterCoordinate = shapeCenterCoordinate ?? throw new ArgumentNullException(nameof(_shapeCenterCoordinate));
            _validate = validate ?? throw new ArgumentNullException(nameof(_validate));
            _typeContainer = typeContainer ?? throw new ArgumentNullException(nameof(_typeContainer));
            _screenElement = screenElement ?? throw new ArgumentNullException(nameof(_screenElement));
        }


        // Устанавливает настройки для режима стрельбы без задержки и без пристрелочных выстрелов
        public void UpperLaserThreshold(Image<Bgr, byte> inputImage, Button button)
        {
            List<Point> screenPoint = DetectScreen(inputImage, _screenPoints);


            if (screenPoint.Count > 0)
            {
                bool isLaserDetected = DetectUpperLaser(screenPoint, inputImage);
                BaseLaserThreshold(inputImage, button, screenPoint, isLaserDetected);
            }
            else
                _screenPoints.Clear();
        }
        // Устанавливает настройки для режима стрельбы с задержкой и пристрелочными выстрелами
        public void LowerLaserThreshold(Image<Bgr, byte> inputImage, Button button)
        {
            List<Point> screenPoint = DetectScreen(inputImage, _screenPoints);

            if (screenPoint.Count > 0)
            {
                bool isLaserDetected = DetectLowerLaser(screenPoint, inputImage);
                BaseLaserThreshold(inputImage, button, screenPoint, isLaserDetected);
            }
            else
                _screenPoints.Clear();
        }

        // Устанавливает общие настройки режимов для стрельбы
        public void BaseLaserThreshold(Image<Bgr, byte> inputImage, Button button, List<Point> landmarks, bool isLaserDetected)
        {
            List<Point> screenPoints = landmarks;

            if (screenPoints.Count >= _typeContainer.ScreenPointsCount)
            {
                bool laserDetected = isLaserDetected;
                _setImageToPictureBox.SetBgrImageToPictureBox(inputImage);
            }
            else
            {
                if (button.InvokeRequired)
                    button.Invoke(new Action(() => { button.Enabled = true; }));
                else
                    button.Enabled = true;

                MessageBox.Show("Вершин недостаточно...", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentOutOfRangeException(nameof(screenPoints));
            }
        }

        // Начинает калибровочный процесс
        public void StartCalibration(Image<Bgr, byte> inputImage)
        {
            DetectScreen(inputImage, _screenPoints);
            _screenPoints.Clear();
            _setImageToPictureBox.SetBgrImageToPictureBox(inputImage);
        }

        // Инициализирует алгоритм поиска лазера для настроек без задержки и без пристрелочных выстрелов
        private bool DetectUpperLaser(List<Point> landmarks, Image<Bgr, byte> inputImage)
        {
            using (VectorOfVectorOfPoint laserContour = new VectorOfVectorOfPoint())
            {
                using (Image<Gray, byte> maskedImage = GetMaskedImage(inputImage, landmarks))
                {
                    using (Mat laserContours = GetLaserContours(laserContour, maskedImage))
                    {
                        for (int i = 1; i < laserContour.Size; i++)
                        {
                            Point laserPoint = _analyzeContours.CalculateContourCenter(laserContour[i]);
                            Point center = _shapeCenterCoordinate.SetUpperCenterCoordinatesUI(laserPoint);
                            _getUI.IsShooting(_analyzeContours.GetContourLength(laserContour[i]), false);
                        }
                    }
                }
            }

            return true;
        }

        // Инициализирует алгоритм поиска лазера для настроек с задержкой и пристрелочными выстрелами
        private bool DetectLowerLaser(List<Point> landmarks, Image<Bgr, byte> inputImage)
        {
            using (VectorOfVectorOfPoint laserContour = new VectorOfVectorOfPoint())
            {
                using (Image<Gray, byte> maskedImage = GetMaskedImage(inputImage, landmarks))
                {
                    using (Mat laserContours = GetLaserContours(laserContour, maskedImage))
                    {
                        for (int i = 1; i < laserContour.Size; i++)
                        {
                            IsContourFind = true;

                            Point laserPoint = _analyzeContours.CalculateContourCenter(laserContour[i]);
                            Point center = _shapeCenterCoordinate.SetLowerCenterCoordinatesUI(laserPoint);
                            _getUI.IsShooting(_analyzeContours.GetContourLength(laserContour[i]), true);
                        }

                        IsContourFind = false;
                    }
                }
            }

            return IsContourFind;
        }

        // Определяет проецируемый экран
        private List<Point> DetectScreen(Image<Bgr, byte> inputImage, List<Point> landmarks)
        {
            using (VectorOfVectorOfPoint screenContours = new VectorOfVectorOfPoint())
            {
                using (VectorOfVectorOfPoint simplifiedContours = new VectorOfVectorOfPoint())
                {
                    using (Image<Gray, byte> screenFilter = GetScreenFilter(inputImage))
                    {
                        using (Mat screenContour = GetScreenContour(screenContours, screenFilter))
                        {
                            for (int i = 0; i < screenContours.Size; i++)
                            {
                                using (VectorOfPoint simpleContour = GetSimpleContour(simplifiedContours, screenContours[i]))
                                {
                                    if (_validate.CheckContourLength(screenContours[i]))
                                        continue;

                                    if (_validate.CheckPointCount(screenContours[i], simpleContour))
                                        continue;

                                    GetSimpleContourAnalyzer(inputImage, simpleContour, landmarks);
                                    _screenElement.ShowScreenElement(inputImage, landmarks, simplifiedContours, simpleContour, i);
                                }
                            }
                        }
                    }
                }
            }

            _getUI.SetResolutionInfo(inputImage);

            return landmarks;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Добавляет упрощенные контуры проецируемого экрана в список
        private void GetSimpleContourAnalyzer(Image<Bgr, byte> inputImage, VectorOfPoint simpleContour, List<Point> landmarks)
        {
            for (int j = 0; j < simpleContour.Size; j++)
            {
                if (_validate.CheckPointsThreshold(landmarks, _typeContainer.MaxScreenPoint))
                    landmarks.Add(simpleContour[j]);
            }
        }

       // Возвращает контуры точек лазера
        private Mat GetLaserContours(VectorOfVectorOfPoint laserContour, Image<Gray, byte> maskedImage) =>
            _analyzeContours.GetLaserContours(laserContour, maskedImage);

        // Возвращает матрицу маски для зоны интереса
        private Image<Gray, byte> GetMaskedImage(Image<Bgr, byte> inputImage, List<Point> landmarks) =>
            _applyFilters.ApplyROIFilter(inputImage, landmarks, _typeContainer.LowLaserThreshold, _typeContainer.UppLaserThreshold);

        // Возвращает упрощенные контуры проецируемого экрана
        private VectorOfPoint GetSimpleContour(VectorOfVectorOfPoint simplifiedContours, VectorOfPoint screenContour) =>
            _analyzeContours.GetSimplifiedScreenContours(simplifiedContours, screenContour);

        // Возвращает контуры проецируемого экрана
        private Mat GetScreenContour(VectorOfVectorOfPoint screenContours, Image<Gray, byte> screenFilter) =>
            _analyzeContours.GetScreenContours(screenContours, screenFilter);

        // Возвращает бинарную матрицу захваченного изображения на основе цветного изображения
        private Image<Gray, byte> GetScreenFilter(Image<Bgr, byte> inputImage) =>
            _applyFilters.ApplyScreenFilter(inputImage, _typeContainer.LowScreenThreshold, _typeContainer.UppScreenThreshold);
    }
}