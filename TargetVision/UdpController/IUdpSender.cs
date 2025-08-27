namespace TargetVision.UdpController
{
    internal interface IUdpSender
    {
        // Создает контракт для отправления координаты по локальному IP.
        public void SendCoordinates(float x, float y);
    }
}
