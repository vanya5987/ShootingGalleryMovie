using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using TargetVision.TypesContainer;

namespace TargetVision.UI
{
    internal class GetUI : IGetUI
    {
        private readonly VideoCapture _videoCapture;
        private readonly PictureBox _pictureBox;
        private readonly Label _coordinatesLabel;
        private readonly Label _shootCountLabel;
        private readonly Label _imageResolution;
        private readonly Label _upperLeftPoint;
        private readonly Label _upperRightPoint;
        private readonly Label _lowerRightPoint;
        private readonly Label _lowerLeftPoint;
        private readonly ITypeContainer _typeContainer;

        private readonly Stopwatch _stopwatch;
        private int _shoot = 1;

        public GetUI(VideoCapture videoCapture, PictureBox pictureBox, Label coordinatesLabel, Label shapeCountLabel,
            Label imageResolution, Label upperLeft, Label upperRight, Label lowerRight, Label lowerLeft, ITypeContainer typeContainer)
        {
            _pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(_pictureBox));
            _coordinatesLabel = coordinatesLabel ?? throw new ArgumentNullException(nameof(_coordinatesLabel));
            _shootCountLabel = shapeCountLabel ?? throw new ArgumentNullException(nameof(_shootCountLabel));
            _imageResolution = imageResolution ?? throw new ArgumentNullException(nameof(_imageResolution));
            _upperLeftPoint = upperLeft ?? throw new ArgumentNullException(nameof(_upperLeftPoint));
            _upperRightPoint = upperRight ?? throw new ArgumentNullException(nameof(_upperRightPoint));
            _lowerRightPoint = lowerRight ?? throw new ArgumentNullException(nameof(_lowerRightPoint));
            _lowerLeftPoint = lowerLeft ?? throw new ArgumentNullException(nameof(_lowerLeftPoint));
            _typeContainer = typeContainer ?? throw new ArgumentNullException(nameof(_typeContainer));

            _videoCapture = videoCapture;

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        // Начинает стрельбу с задержкой и пристрелочными выстрелами
        public void IsShooting(double contourLength, bool isDelay)
        {
            if (_stopwatch.ElapsedMilliseconds >= _typeContainer.MethodDelay)
            {
                UppShootUpdate(isDelay);
                _stopwatch.Restart();
            }
        }

        // Начинает стрельбу без задержки и без пристрелочных выстрелов
        public void LowShootUpdate()
        {
            if (_stopwatch.ElapsedMilliseconds >= _typeContainer.MethodDelay)
                UpdateUI($"Кол-во попаданий: {_shoot++}", _shootCountLabel);
        }

        // Применяет настройки к стрельбе с задержкой и пристрелочными выстрелами
        private void UppShootUpdate( bool isDelay)
        {
            if (_stopwatch.ElapsedMilliseconds >= _typeContainer.MethodDelay && !isDelay)
                UpdateUI($"Кол-во попаданий: {_shoot++}", _shootCountLabel);
        }

        // Обновляет текст модулей UI 
        public void UpdateUI(string value, Label label)
        {
            if (label.InvokeRequired)
                label.Invoke(new Action(() => label.Text = value));
            else
                label.Text = value;
        }
        
        // Обновляет модули UI с информацией о градусах углов
        public void ShowSquareAngle(string upperLeft, string upperRight, string lowerRight, string lowerLeft)
        {
            UpdateUI($"Верхний-левый угол: {upperLeft}°", _upperLeftPoint);
            UpdateUI($"Верхний-правый угол: {upperRight}°", _upperRightPoint);
            UpdateUI($"Нижний-правый угол: {lowerRight}°", _lowerRightPoint);
            UpdateUI($"Нижний-левый угол: {lowerLeft}°", _lowerLeftPoint);
        }

        // Обнволяет лейблы с информацией о градусах углов
        public void ResetLabels()
        {
            if (_upperLeftPoint != null && !_upperLeftPoint.IsDisposed)
                _upperLeftPoint.Text = "Верхний-левый угол:";
            if (_upperRightPoint != null && !_upperRightPoint.IsDisposed)
                _upperRightPoint.Text = "Верхний-правый угол:";
            if (_lowerLeftPoint != null && !_lowerLeftPoint.IsDisposed)
                _lowerLeftPoint.Text = "Нижний-левый угол:";
            if (_lowerRightPoint != null && !_lowerRightPoint.IsDisposed)
                _lowerRightPoint.Text = "Нижний-правый угол:";
        }

        // Устанавливает разрешение картинки в лейбл
        public void SetResolutionInfo(Image<Bgr, byte> image) => UpdateUI($"{image.Width}x{image.Height}", _imageResolution);

        // Возвращает видео - захвтачик
        public VideoCapture GetVideoCapture() => _videoCapture;

        // Возвращает панель для видео - захвата
        public PictureBox GetPictureBox() => _pictureBox;

        // Возвращает лейбл координат
        public Label GetCoordinates() => _coordinatesLabel;

        // Возвращает лейбл с кол-вом определенных лазеров
        public Label GetShootCount() => _shootCountLabel;

        // Возвращает лейбл с разрешением картинки
        public Label GetImageResolution() => _imageResolution;

        // Возвращает лейбл с градусами верхней левой точки
        public Label UpperLeftPoint() => _upperLeftPoint;

        // Возвращает лейбл с градусами верхней правой точки
        public Label UpperRightPoint() => _lowerRightPoint;

        // Возвращает лейбл с градусами нижней правой точки
        public Label LowerRightPoint() => _upperRightPoint;

        // Возвращает лейбл с градусами нижней левой точки
        public Label LowerLeftPoint() => _lowerLeftPoint;
    }
}