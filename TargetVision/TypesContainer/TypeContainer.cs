namespace TargetVision.TypesContainer
{
    // Хранит конфигурационные поля для настройки ядра.
    internal class TypeContainer : ITypeContainer
    {
        public int LowScreenThreshold { get; set; } = 100; // 100 с red фильтром. //***Вывели в консоль настроек***
        public int UppScreenThreshold { get; set; } = 255; // 255 с red фильтром. //***Вывели в консоль настроек***
        public int LowLaserThreshold { get; set; } = 230; // 230 без фильтра. // Для пистолета - 235 с red фильтром. //***Вывели в консоль настроек***
        public int UppLaserThreshold { get; set; } = 255; // 255 без фильтра. // 255 - с red фильтром. //***Вывели в консоль настроек***

        public int LowScreenContourLength { get; set; } = 10 * 100; // Приблизительное значение - 1000.  //***Вывели в консоль настроек***
        public int UppScreenContourLength { get; set; } = 16 * 100; // Приблизительное значение - 1600.  //***Вывели в консоль настроек***

        public int MaxScreenPoint { get; set; } = 16; // Максимальное кол - во точек экрана для сортировки. //***Не имеет смысла выводить(Для разработчика)***
        public int ScreenVectorOfPointCount { get; set; } = 8; // Рекомендованное значение. //***Не имеет смысла выводить(Для разработчика)***
        public int ScreenPointsCount { get; set; } = 4; // Рекомендованное значение. //***Не имеет смысла выводить(Для разработчика)***
        public int MethodDelay { get; set; } = 200; // Задержка для срабатывания метода. //***Не имеет смысла выводить(Для разработчика)***
        public int LaserDelay { get; set; } = 5000; // Функциональная задержка для лазера. //***Вывели в консоль настроек***
    }
}
