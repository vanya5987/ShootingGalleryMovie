namespace TargetVision.TypesContainer
{
    internal interface ITypeContainer
    {
        // Возвращает нижний порог светимости экрана
        public int LowScreenThreshold { get; set; }

        // Возвращает верхний порог светимости экрана
        public int UppScreenThreshold { get; set; }

        // Возвращает нижний порог светимости лазера
        public int LowLaserThreshold { get; set; }

        // Возвращает верхний порог светимости лазера
        public int UppLaserThreshold { get; set; } 

        // Возвращает минимальный размер конутра проецируемого экрана
        public int LowScreenContourLength { get; set; }

        // Возвращает максимальный размер конутра проецируемого экрана
        public int UppScreenContourLength { get; set; } 

        // Возвращает максимальное количество углов для проецируемого экрана
        public int MaxScreenPoint { get; set; }

        // Возвращает количество контуров для проецируемого экрана
        public int ScreenVectorOfPointCount { get; set; } 

        // Возвращает количество точек углов для проецируемого экрана
        public int ScreenPointsCount { get; set; } 

        // Возвращает задержку для отработки метода отображения лазера
        public int MethodDelay { get; set; }

        // Возвращает задержку для лазера в секундах
        public int LaserDelay { get; set; }
    }
}
