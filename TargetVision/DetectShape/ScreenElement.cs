using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using TargetVision.Angle;
using TargetVision.DrawHandler;
using TargetVision.UI;

namespace TargetVision.DetectShape
{
    internal class ScreenElement : IScreenElement
    {
        private readonly IGetUI _getUI;
        private readonly IDraw _draw;
        private readonly IAnglesSorter _anglesSorter;
        private readonly IAngleComputer _angleComputer;

        public ScreenElement(IGetUI getUI, IDraw draw, IAnglesSorter anglesSorter, IAngleComputer angleComputer)
        {
            _getUI = getUI ?? throw new ArgumentNullException(nameof(_getUI));
            _draw = draw ?? throw new ArgumentNullException(nameof(_draw));
            _anglesSorter = anglesSorter ?? throw new ArgumentNullException(nameof(_anglesSorter));
            _angleComputer = angleComputer ?? throw new ArgumentNullException(nameof(_angleComputer));
        }

        // Устанавливает информацию о захваченном проецируемом экране в UI модуль
        public void ShowScreenElement(Image<Bgr, byte> inputImage, List<Point> landmarks, VectorOfVectorOfPoint simplifiedContours, VectorOfPoint simpleContour, int i)
        {
            List<Point> sortedLandmarks = _anglesSorter.SortedPoints(landmarks);
            List<string> sortedAngles = _angleComputer.CalculateAngles(sortedLandmarks);

            _getUI.ShowSquareAngle(sortedAngles[0], sortedAngles[1], sortedAngles[2], sortedAngles[3]);
            sortedAngles.Clear();
            _draw.DrawShapeContours(simplifiedContours, i, inputImage);
            _draw.ShowContourLength(simpleContour, i);
        }
    }
}
