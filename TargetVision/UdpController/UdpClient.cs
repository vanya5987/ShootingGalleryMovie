using System.Net;
using System.Net.Sockets;

namespace TargetVision.UdpController
{
    internal class UdpSender : IUdpSender
    {
        private readonly UdpClient _sender = new UdpClient();
        private readonly IPEndPoint _endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);

        // Отправляет координаты по локальному IP.
        public void SendCoordinates(float x, float y)
        {
            string message = $"{x},{y}";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            _sender.Send(data, data.Length, _endPoint);
        }
    }
}