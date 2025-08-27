using Emgu.CV;
using Emgu.CV.Structure;

namespace TargetVision.UI
{
    internal interface IGetUI
    {
        public void ShowSquareAngle(string upperLeft, string upperRight, string lowerRight, string lowerLeft);

        // Создает контракт для обновлений лейблов
        public void ResetLabels();

        // Создает контракт для обновления информации при стрельбе в свободном режиме
        public void LowShootUpdate();

        // Создает контракт для обновления информации при стрельбе в режиме с задеркой и пристрелочными выстрелами
        public void IsShooting(double contourLength, bool isDelay);

        // Устанаувливает в лейбл инофрмацию о разрешении картинки
        public void SetResolutionInfo(Image<Bgr, byte> image);

        // Создает контракт на возвращение видео - захватчика
        public VideoCapture GetVideoCapture();

        // Создает контракт на возвращение панели видеозахвата
        public PictureBox GetPictureBox();

        // Создает контракт на возвращение лейбла с информацией о координатах
        public Label GetCoordinates();

        // Создает контракт на возвращение лейбла с информацией о кол-ве найденых лазеров
        public Label GetShootCount();

        // Создает контракт на возвращение лейбла с информацией о разрешении картинки
        public Label GetImageResolution();

        // Создает контракт на возвращение лейбла с информацией о градусах верхней левой точки
        public Label UpperLeftPoint();

        // Создает контракт на возвращение лейбла с информацией о градусах верхней правой точки
        public Label UpperRightPoint();

        // Создает контракт на возвращение лейбла с информацией о градусах нижней правой точки
        public Label LowerRightPoint();

        // Создает контракт на возвращение лейбла с информацией о градусах нижней левой точки
        public Label LowerLeftPoint();
    }
}
