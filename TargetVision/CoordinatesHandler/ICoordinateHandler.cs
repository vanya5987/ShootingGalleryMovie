namespace TargetVision.CoordinatesHandler
{
    internal interface ICoordinateHandler
    {
        // Создает контракт для установки кординат в UI компонент.
        public Point SetUpperCenterCoordinatesUI(Point center);

        // Создает контракт для установки кординат в UI компонент.
        public Point SetLowerCenterCoordinatesUI(Point center);
    }
}
