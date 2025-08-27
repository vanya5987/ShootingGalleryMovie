using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using TargetVision.ContoursAnalyzer;
using TargetVision.UI;

namespace TargetVision.DrawHandler
{
    internal class Draw : IDraw
    {
        private readonly IAnalyzeContours _analyzeContours;
        private readonly IGetUI _getUI;

        public Draw(IAnalyzeContours analyzeContours, IGetUI getUI)
        {
            _analyzeContours = analyzeContours ?? throw new ArgumentNullException(nameof(_analyzeContours));
            _getUI = getUI ?? throw new ArgumentNullException(nameof(_getUI));
        }

        // Отображае в UI компоненте статут обнаружения экрана
        public void ShowContourLength(VectorOfPoint simpleContour, int i)
        {
            if (_getUI.GetCoordinates().InvokeRequired)

                _getUI.GetCoordinates().Invoke(new Action(() =>
                {
                    _getUI.GetCoordinates().Text = $"Экран обнаружен!"; //Контур {i + 1}: {simpleContour.Size} точек
                }));
            else
                _getUI.GetCoordinates().Text = $"Экран обнаружен!"; //Контур {i + 1}: {simpleContour.Size} точек
        }

        // Отрисовывыет центр контура фигуры
        public void DrawShapeCenter(VectorOfPoint contour, Image<Bgr, byte> inputImage) => CvInvoke.Circle(inputImage, _analyzeContours.CalculateContourCenter(contour), 3, new MCvScalar(255, 0, 0), 3);

        // Отрисовывает контур фигуры
        public void DrawShapeContours(VectorOfVectorOfPoint contours, int i, Image<Bgr, byte> inputImage) => CvInvoke.DrawContours(inputImage, contours, i, new MCvScalar(0, 255, 0), 2);

        // Отрисовывает угловые точки проецируемого экрана
        public void DrawScreenPoins(Image<Bgr, byte> inputImage, Point point) => CvInvoke.Circle(inputImage, point, 3, new MCvScalar(0, 255, 0), -1);
    }
}
