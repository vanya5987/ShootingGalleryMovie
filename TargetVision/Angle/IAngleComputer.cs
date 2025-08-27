namespace TargetVision.Angle
{
    internal interface IAngleComputer
    {
        //Создает контракт для вычисления градусов одного угла на основе 2-х соседних точек
        public List<string> CalculateAngles(List<Point> points);
    }
}
