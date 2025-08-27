using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TargetVision.DrawHandler
{
    internal interface IDraw
    {
        // Создает контракт для отрисовки центра фигуры
        public void DrawShapeCenter(VectorOfPoint contour, Image<Bgr, byte> inputImage);

        // Создает контракт для отрисовки контура фигуры
        public void DrawShapeContours(VectorOfVectorOfPoint contours, int i, Image<Bgr, byte> inputImage);

        // Создает контракт для отрисовки угловых точек проецируемого экрана
        public void DrawScreenPoins(Image<Bgr, byte> inputImage, Point point);

        // Создает контракт для отображения размера контура в UI компоненте
        public void ShowContourLength(VectorOfPoint simpleContour, int i);
    }
}
