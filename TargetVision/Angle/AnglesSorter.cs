
namespace TargetVision.Angle
{
    internal class AnglesSorter : IAnglesSorter
    {
        // Находит и сортирует точки углов экрана
        public List<Point> SortedPoints(List<Point> points)
        {
            // Находим индексы самой левой, правой, верхней и нижней точек
            int leftmost = 0, rightmost = 0, topmost = 0, bottommost = 0;
            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X < points[leftmost].X) leftmost = i;
                if (points[i].X > points[rightmost].X) rightmost = i;
                if (points[i].Y < points[topmost].Y) topmost = i;
                if (points[i].Y > points[bottommost].Y) bottommost = i;

                // Создаем список из найденных точек
                List<Point> cornerPoints = new List<Point>() { points[topmost], points[rightmost], points[bottommost], points[leftmost] };
            }

            return points;
        }
    }
}
