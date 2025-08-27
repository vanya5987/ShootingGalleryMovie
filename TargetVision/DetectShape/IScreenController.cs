using Emgu.CV;
using Emgu.CV.Structure;

namespace TargetVision.DetectShape
{
    internal interface IScreenController
    {
        // Создает контракт для устанавки настройки для режима стрельбы без задержки и без пристрелочных выстрелов
        public void UpperLaserThreshold(Image<Bgr, byte> inputImage, Button button);

        // Создает контракт для устанавки настройки для режима стрельбы с задержкой и пристрелочными выстрелами
        public void LowerLaserThreshold(Image<Bgr, byte> inputImage, Button button);

        // Создает контракт для старта калибровки
        public void StartCalibration(Image<Bgr, byte> inputImage);
    }
}
