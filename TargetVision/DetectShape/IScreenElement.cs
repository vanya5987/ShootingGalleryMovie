using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TargetVision.DetectShape
{
    internal interface IScreenElement
    {
        // Создает контракт на устанавку информации о захваченном проецируемом экране в UI модуль
        public void ShowScreenElement(Image<Bgr, byte> inputImage, List<Point> landmarks, VectorOfVectorOfPoint simplifiedContours, VectorOfPoint simpleContour, int i);
    }
}
