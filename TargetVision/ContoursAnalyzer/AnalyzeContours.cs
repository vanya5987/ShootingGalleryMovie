using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TargetVision.ContoursAnalyzer
{
    internal class AnalyzeContours : IAnalyzeContours
    {
        private readonly double _epsilon = 10.0; // 10.0 - уровень упрощения

        // Получаем контур проецируемого экрана
        public Mat GetScreenContours(VectorOfVectorOfPoint contours, Image<Gray, byte> thresholdImage)
        {
            using (Mat hierarchy = new Mat())
            {
                CvInvoke.FindContours(thresholdImage, contours, hierarchy,
                    Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            }

            return new Mat();
        }

        // Получаем контуры лазера
        public Mat GetLaserContours(VectorOfVectorOfPoint contours, Image<Gray, byte> thresholdImage)
        {
            using (Mat hierarchy = new Mat())
            {
                CvInvoke.FindContours(thresholdImage, contours, hierarchy,
               Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            }

            return new Mat();
        }

        // Упращаем контура экрана и получаем его
        public VectorOfPoint GetSimplifiedScreenContours(VectorOfVectorOfPoint simplifiedContours, VectorOfPoint contour)
        {
            VectorOfPoint simplifiedContour = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(contour, simplifiedContour, _epsilon, true);

            simplifiedContours.Push(simplifiedContour);

            return simplifiedContour;
        }

        // Получаем центр переданого контура
        public Point CalculateContourCenter(VectorOfPoint contour) //Вычисляет точку которую нужно добавить
        {
            if (contour == null || contour.Size == 0)
                throw new ArgumentException("Контур не должен быть пустым.", nameof(contour));

            // Вычисляем моменты контура
            Moments moments = CvInvoke.Moments(contour);

            // Вычисляем координаты центра
            int centerX = (int)(moments.M10 / moments.M00);
            int centerY = (int)(moments.M01 / moments.M00);

            return new Point(centerX, centerY);
        }

        // Получаем длину контура
        public double GetContourLength(VectorOfPoint contour) => CvInvoke.ArcLength(contour, true);

        // Получаем зону конутра
        public double GetContourArea(VectorOfPoint contour) => CvInvoke.ContourArea(contour, false);
    }
}
