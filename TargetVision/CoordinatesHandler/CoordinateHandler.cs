using System.Diagnostics;
using TargetVision.DetectShape;
using TargetVision.TypesContainer;
using TargetVision.UdpController;
using TargetVision.UI;

namespace TargetVision.CoordinatesHandler
{
    internal class CoordinateHandler : ICoordinateHandler
    {
        private readonly IGetUI _getUI;
        private readonly IUdpSender _udpSender;
        private readonly ITypeContainer _typeContainer;
        private readonly ListBox _listBox;
        private readonly List<string> _coordinates;
        private readonly Stopwatch _stopwatch;
        private readonly List<Point> _laserPoints;

        private int _delay;

        public CoordinateHandler(IGetUI getUI, IUdpSender udpSender, ListBox listBox, List<string> coordinates, List<Point> laserPoints, ITypeContainer typeContainer)
        {
            _getUI = getUI ?? throw new ArgumentNullException(nameof(_getUI));
            _udpSender = udpSender ?? throw new ArgumentNullException(nameof(_udpSender));
            _listBox = listBox ?? throw new ArgumentNullException(nameof(_listBox));
            _coordinates = coordinates ?? throw new ArgumentNullException(nameof(_coordinates));
            _laserPoints = laserPoints ?? throw new ArgumentNullException(nameof(_laserPoints));
            _typeContainer = typeContainer ?? throw new ArgumentNullException(nameof(_typeContainer));

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _delay = _typeContainer.MethodDelay;
        }

        // Инициирует событие по обновлению listBox
        public Point SetCenterCoordinateUI(Point center, int delay, bool isContourFind)
        {
            if (_getUI.GetCoordinates().InvokeRequired)
                _getUI.GetCoordinates().Invoke(new Action(() => UpdateUI(center, delay, isContourFind)));
            else
                UpdateUI(center, delay, isContourFind);

            return center;
        }

        // Добавляет кординаты в listBox с определенным временным промежутком
        private void UpdateUI(Point center, int delay, bool isContourFind)
        {
            if (_stopwatch.ElapsedMilliseconds >= delay)
            {
                SetShootValue(center, isContourFind);
                _stopwatch.Restart();
            }
        }

        // Добавляет кординаты в listBox
        private void SetShootValue(Point center, bool isContourFind)
        {
            string coordinates = $"Координаты: X={center.X}, Y={center.Y}";

            if (isContourFind == false)
            {
                _udpSender.SendCoordinates(center.X, center.Y);
                _listBox.Items.Add(coordinates);
            }

            if (isContourFind == true)
                if (ScreenController.IsContourFind)
                {
                    _coordinates.Add(coordinates);
                    _laserPoints.Add(new Point(center.X, center.Y));
                }
        }

        // Устанавливает координаты в UI компонент.
        public Point SetUpperCenterCoordinatesUI(Point center) => SetCenterCoordinateUI(center, _delay, false);

        // Устанавливает координаты в UI компонент.
        public Point SetLowerCenterCoordinatesUI(Point center) => SetCenterCoordinateUI(center, _delay, true);
    }
}