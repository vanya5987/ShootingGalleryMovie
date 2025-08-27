using TargetVision.UI;

namespace TargetVision.Angle
{
    internal class AngleComputer : IAngleComputer
    {
        private readonly IGetUI _getUI;

        private readonly List<string> _landmarksAngle;

        public AngleComputer(IGetUI getUI, List<string> landmarksAngle)
        {
            _getUI = getUI ?? throw new ArgumentNullException(nameof(_getUI));
            _landmarksAngle = landmarksAngle ?? throw new ArgumentNullException(nameof(_landmarksAngle));
        }

        // Вычисляет градусы углов на основе 2-х соседних точек
        public List<string> CalculateAngles(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Point p1 = points[i]; // центральная точка
                Point p2 = points[(i + 1) % points.Count]; // следующая точка
                Point p3 = points[(i + 3) % points.Count]; // предыдущая точка

                if (_landmarksAngle.Count <= 4)
                    _landmarksAngle.Add($"{CalculateAngle(p1, p2, p3)}");
            }

            return _landmarksAngle;
        }

        // Вычисляет градусы одного угла на основе 2-х соседних точек
        private int CalculateAngle(Point vertex, Point point1, Point point2)
        {
            // Вектора
            double vector1X = point1.X - vertex.X;
            double vector1Y = point1.Y - vertex.Y;
            double vector2X = point2.X - vertex.X;
            double vector2Y = point2.Y - vertex.Y;

            // Длина векторов
            double length1 = Math.Sqrt(vector1X * vector1X + vector1Y * vector1Y);
            double length2 = Math.Sqrt(vector2X * vector2X + vector2Y * vector2Y);

            // Скалярное произведение
            double dotProduct = vector1X * vector2X + vector1Y * vector2Y;

            // Угол в радианах
            double angleRadians = Math.Acos(dotProduct / (length1 * length2));
            double angleDegrees = angleRadians * (180 / Math.PI);

            return (int)angleDegrees;
        }
    }
}