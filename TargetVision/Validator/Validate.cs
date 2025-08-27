using Emgu.CV.Util;
using TargetVision.ContoursAnalyzer;
using TargetVision.TypesContainer;

namespace TargetVision.Validator
{
    internal class Validate : IValidate
    {
        private readonly IAnalyzeContours _analyzeContours;
        private readonly ITypeContainer _typeContainer;

        public Validate(IAnalyzeContours analyzeContours, ITypeContainer typeContainer)
        {
            _analyzeContours = analyzeContours ?? throw new ArgumentNullException(nameof(_analyzeContours));
            _typeContainer = typeContainer ?? throw new ArgumentNullException(nameof(_typeContainer));
        }

        // Проверяет колличество точек контура на их допустимое колличество
        public bool IsValidPointCount(VectorOfPoint contour, int lowPointCount, int upperPointCount) => contour.Size > upperPointCount || contour.Size < lowPointCount;

        // Проверяет зону контура на валидность
        public bool IsValidLength(VectorOfVectorOfPoint contours, int i, int minContourLength, int maxContourLength) =>
            _analyzeContours.GetContourArea(contours[i]) < maxContourLength || _analyzeContours.GetContourArea(contours[i]) > minContourLength;

        // Проверяет коллиество точек проецируемого экрана на их валидность
        public bool CheckPointsThreshold(List<Point> landmarks, int pointsThreshold) => landmarks.Count < pointsThreshold;

        // Проверяет размер контура на валидность
        public bool CheckContourLength(VectorOfPoint contour) => _analyzeContours.GetContourLength(contour) < _typeContainer.LowScreenContourLength ||
            _analyzeContours.GetContourLength(contour) > _typeContainer.UppScreenContourLength;

        // Проверяет колличество точек экрана на соответствие точек контура упрощенного экрана
        public bool CheckPointCount(VectorOfPoint screenContours, VectorOfPoint simpleContour) => screenContours.Size < _typeContainer.ScreenVectorOfPointCount ||
            simpleContour.Size > _typeContainer.ScreenPointsCount;
    }
}
