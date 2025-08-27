using Emgu.CV;

namespace TargetVision.PicturesCapture
{
    internal interface ICaptureImage
    {
        // Создает контракт для получения матриц для калибровки
        public Mat GetCalibrateCapture();
    }
}
