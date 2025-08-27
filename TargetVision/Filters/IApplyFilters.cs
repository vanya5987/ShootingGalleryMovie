using Emgu.CV;
using Emgu.CV.Structure;

namespace TargetVision.Filters
{
    internal interface IApplyFilters
    {
        // Создает контракт для получения матрицы зоны интереса
        public Image<Gray, byte> ApplyROIFilter(Image<Bgr, byte> inputImage, List<Point> landmarks, int lowThreshold, int uppThreshold);

        // Создает контракт для получения матрицы проецируемого экрана
        public Image<Gray, byte> ApplyScreenFilter(Image<Bgr, byte> inputImage, double lowThreshold, double uppThreshold);
    }
}
