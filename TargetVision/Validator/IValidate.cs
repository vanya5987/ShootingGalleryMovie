using Emgu.CV.Util;

namespace TargetVision.Validator
{
    internal interface IValidate
    {
        //Создает контракт на проверку колличества точек контура на их допустимое колличество
        public bool IsValidPointCount(VectorOfPoint contour, int lowPointCount, int upperPointCount);

        // Создает контракт на проверку зоны контура на валидность
        public bool IsValidLength(VectorOfVectorOfPoint contours, int i, int minContourLength, int maxContourLength);

        // Создает контракт на проверку коллиества точек проецируемого экрана на их валидность
        public bool CheckPointsThreshold(List<Point> landmarks, int pointsThreshold);

        // Создает контракт на проверку размера контура на валидность
        public bool CheckContourLength(VectorOfPoint contour);

        // Создает контракт на проверку колличества точек экрана на соответствие точек контура упрощенного экрана
        public bool CheckPointCount(VectorOfPoint screenContours, VectorOfPoint simpleContour);
    }
}
