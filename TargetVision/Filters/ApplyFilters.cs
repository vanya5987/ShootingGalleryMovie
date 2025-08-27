using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using TargetVision.Angle;

namespace TargetVision.Filters
{
    internal class ApplyFilters : IApplyFilters
    {
        private const int _imageWidth = 1280;
        private const int _imageHeight = 720;

        private const int _maxLandmarksCount = 8;

        private const int _maskColor = 0;
        private const int _backgroundColor = 255;

        private readonly IAnglesSorter _anglesSorter;

        public ApplyFilters(IAnglesSorter anglesSorter)
        {
            _anglesSorter = anglesSorter ?? throw new ArgumentNullException(nameof(_anglesSorter));
        }

        // Возвращает матрицу для зоны интереса
        public Image<Gray, byte> ApplyROIFilter(Image<Bgr, byte> inputImage, List<Point> landmarks, int lowThreshold, int uppThreshold)
        {
            List<Point> sortedPoints = _anglesSorter.SortedPoints(landmarks);

            VectorOfPoint contour = new VectorOfPoint(sortedPoints.ToArray());
            Image<Gray, byte> thresholdImage = ApplyBaseLaserFilter(inputImage, sortedPoints, lowThreshold, uppThreshold, contour);

            // Находим ограничивающий прямоугольник для ROI
            Rectangle boundingRect = CvInvoke.BoundingRectangle(contour);

            // Обрезаем изображение по границам ROI
            Image<Gray, byte> croppedImage = thresholdImage.GetSubRect(boundingRect).Clone();

            // Изменяем размер изображения до 1280x720
            Image<Gray, byte> resizedImage = croppedImage.Resize(_imageWidth, _imageHeight, Inter.Linear);

            return resizedImage.Not(); // Без фильтра Not() присутствует.
        }

        // Возвращает матрицу для лазера
        private Image<Gray, byte> ApplyBaseLaserFilter(Image<Bgr, byte> inputImage, List<Point> landmarks, int lowThreshold, int uppThreshold, VectorOfPoint contour)
        {
            Image<Gray, byte> grayImage = inputImage.Convert<Gray, byte>();

            // Создаём маску
            Image<Gray, byte> mask = new Image<Gray, byte>(inputImage.Width, inputImage.Height, new Gray(_maskColor));

            // Заполняем полигон
            if (landmarks.Count > _maxLandmarksCount)
                CvInvoke.FillConvexPoly(mask, contour, new MCvScalar(_backgroundColor), LineType.EightConnected);

            // Применяем маску к исходному изображению в градациях серого
            Image<Gray, byte> maskedImage = grayImage.Copy();
            maskedImage.SetValue(_maskColor, mask.Not());

            return maskedImage.ThresholdBinary(new Gray(lowThreshold), new Gray(uppThreshold));
        }

         // Возвращает матрицу для проецируемого экрана
        public Image<Gray, byte> ApplyScreenFilter(Image<Bgr, byte> bgrImage, double lowThreshold, double uppThreshold)
        {
            // Инвертируем изображение
            Mat invertedImage = new Mat();
            CvInvoke.BitwiseNot(bgrImage, invertedImage);

            // Применяем фильтр к изображению
            Mat bgrWithFilter = invertedImage - bgrImage.Mat;

            // Преобразуем в оттенки серого
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(bgrWithFilter, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            // Применяем пороговую обработку
            Mat thresholdImage = new Mat();
            CvInvoke.Threshold(grayImage, thresholdImage, lowThreshold, uppThreshold, ThresholdType.Binary);

            // Применяем морфологические операции для уменьшения шума
            Mat morphedImage = new Mat();
            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1)); // Создаем корректирующий элемент
            CvInvoke.Erode(thresholdImage, morphedImage, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));  // Эрозия для удаления небольших шумов
            CvInvoke.Dilate(morphedImage, morphedImage, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0)); // Дилатация для восстановления размеров объектов

            // Конвертируем обратно в формат изображения
            Image<Gray, byte> resultImage = morphedImage.ToImage<Gray, byte>();

            return resultImage.Not(); // Инвертируем изображение, чтобы получить финальный результат
        }
    }
}
