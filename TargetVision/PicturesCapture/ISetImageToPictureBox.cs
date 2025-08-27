using Emgu.CV;
using Emgu.CV.Structure;

namespace TargetVision.PicturesCapture
{
    internal interface ISetImageToPictureBox
    {
        // Создает контракт на установку цветной картинки в UI модуль
        public void SetBgrImageToPictureBox(Image<Bgr, byte> inputImage);

        // Создает контракт на установку бинарной картинки в UI модуль
        public void SetGrayImageToPictureBox(Image<Gray, byte> inputImage);
    }
}
