using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TargetVision.ContoursAnalyzer
{
    internal interface IAnalyzeContours
    {
        // Создаем контракт для получения контура проецируемого экрана
        public Mat GetScreenContours(VectorOfVectorOfPoint contours, Image<Gray, byte> grayImage);

        // Создаем контракт для получения точки лазера
        public Mat GetLaserContours(VectorOfVectorOfPoint contours, Image<Gray, byte> grayImage);

        // Создаем контракт для получения длины контура
        public double GetContourLength(VectorOfPoint contour);

        // Создаем контракт для получения зоны контура
        public double GetContourArea(VectorOfPoint contour);

        // Создаем контракт для получения центра контура
        public Point CalculateContourCenter(VectorOfPoint contour);

        // Создаем контракт для получения упрощенного контура экрана
        public VectorOfPoint GetSimplifiedScreenContours(VectorOfVectorOfPoint simplifiedContours, VectorOfPoint contour);
    }
}
