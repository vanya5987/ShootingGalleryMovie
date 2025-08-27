namespace TargetVision.Angle
{
    internal interface IAnglesSorter
    {
        // Создает контракт для нахождения и сортировки точки углов экрана
        public List<Point> SortedPoints(List<Point> points);
    }
}
