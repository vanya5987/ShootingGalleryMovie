using Emgu.CV;
using Emgu.CV.Structure;
using TargetVision.UI;

namespace TargetVision.PicturesCapture
{
    internal class CaptureImage : ICaptureImage, ISetImageToPictureBox
    {
        private readonly IGetUI _getUI;

        public CaptureImage(IGetUI getUI)
        {
            _getUI = getUI ?? throw new ArgumentNullException(nameof(_getUI));
        }

        // Возвращает матрицы для калибровки
        public Mat GetCalibrateCapture()
        {
            Mat matFrame = new Mat();

            if (!_getUI.GetVideoCapture().Retrieve(matFrame))
            {
                string errorMessage = "Не удалось захватить кадр.";
                MessageBox.Show($"Ошибка при захвате кадра: {errorMessage}");
                throw new InvalidOperationException($"Ошибка при захвате кадра: {errorMessage}");
            }

            return matFrame.Clone();
        }

        // Устанавливает цветную картинку в UI модуль
        public void SetBgrImageToPictureBox(Image<Bgr, byte> inputImage)
        {
            if (_getUI.GetPictureBox().InvokeRequired)
                _getUI.GetPictureBox().Invoke(new Action(() => _getUI.GetPictureBox().Image = inputImage.ToBitmap()));
            else
                _getUI.GetPictureBox().Image = inputImage.ToBitmap();
        }

        // Устанавливает бинарную картинку в UI модуль
        public void SetGrayImageToPictureBox(Image<Gray, byte> inputImage)
        {
            if (_getUI.GetPictureBox().InvokeRequired)
                _getUI.GetPictureBox().Invoke(new Action(() => _getUI.GetPictureBox().Image = inputImage.ToBitmap()));
            else
                _getUI.GetPictureBox().Image = inputImage.ToBitmap();
        }
    }
}

