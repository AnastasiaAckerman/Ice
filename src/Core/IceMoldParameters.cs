    namespace Core
{
    /// <summary>
    /// Класс хранящий параметры винта
    /// </summary>
    public class IceMoldParameters
    {
        /// <summary>
        /// Длина формы
        /// </summary>
        private static IceMoldParameter _iceMoldLength =
            new(IceMoldParameterType.IceMoldLength,
                MaxIceMoldLength, MinIceMoldLength);

        /// <summary>
        /// Ширина формы
        /// </summary>
        private static IceMoldParameter _iceMoldWidth =
            new(IceMoldParameterType.IceMoldWidth,
                MaxIceMoldWidth, MinIceMoldWidth);

        /// <summary>
        /// Глубина формы
        /// </summary>
        private static IceMoldParameter _iceMoldDeep =
            new(IceMoldParameterType.IceMoldDeep,
                MaxIceMoldDeep, MinIceMoldDeep);

        /// <summary>
        /// Толщина внешних стенок
        /// </summary>
        private static IceMoldParameter _externalWall =
            new(IceMoldParameterType.ExternalWall,
                MaxExternalWall, MinExternalWall);

        /// <summary>
        /// Толщина внутренних стенок
        /// </summary>
        private static IceMoldParameter _innerWall =
            new(IceMoldParameterType.InnerWall,
                MaxInnerWall, MinInnerWall);

        /// <summary>
        /// Толщина днища формы
        /// </summary>
        private static IceMoldParameter _iceMoldBottom =
            new(IceMoldParameterType.IceMoldBottom,
                MaxIceMoldBottom, MinIceMoldBottom);

        /// <summary>
        /// Количество ячеек на ширину формы
        /// </summary>
        private static IceMoldParameter _cellsWidthCount =
            new(IceMoldParameterType.CellsWidthCount,
                MaxCellsWidthCount, MinCellsWidthCount);

        /// <summary>
        /// Количество ячеек на длину формы
        /// </summary>
        private static IceMoldParameter _cellsLengthCount =
            new(IceMoldParameterType.CellsLengthCount,
                MaxCellsLengthCount, MinCellsLengthCount);

        /// <summary>
        /// Словарь содержащий пары (Имя параметра, указатель на него)
        /// </summary>
        private Dictionary<IceMoldParameterType, IceMoldParameter>
            _parametersDictionary =
                new()
                {
                    {_iceMoldLength.Name, _iceMoldLength},
                    {_iceMoldWidth.Name, _iceMoldWidth},
                    {_iceMoldDeep.Name, _iceMoldDeep},
                    {_externalWall.Name, _externalWall},
                    {_innerWall.Name, _innerWall},
                    {_iceMoldBottom.Name, _iceMoldBottom},
                    {_cellsWidthCount.Name, _cellsWidthCount},
                    {_cellsLengthCount.Name, _cellsLengthCount},
                };

        /// <summary>
        /// Минимальное значение длины формы
        /// </summary>
        public const int MinIceMoldLength = 100;

        /// <summary>
        /// Максимальное значение длины формы
        /// </summary>
        public const int MaxIceMoldLength = 150;

        /// <summary>
        /// Минимальное значение ширины формы
        /// </summary>
        public const int MinIceMoldWidth = 250;

        /// <summary>
        /// Максимальное значение ширины формы
        /// </summary>
        public const int MaxIceMoldWidth = 300;

        /// <summary>
        /// Минимальное значение глубины формы
        /// </summary>
        public const int MinIceMoldDeep = 20;

        /// <summary>
        /// Максимальное значение глубины формы
        /// </summary>
        public const int MaxIceMoldDeep = 40;

        /// <summary>
        /// Минимальное значение толщины внешней стенки формы
        /// </summary>
        public const int MinExternalWall = 5;

        /// <summary>
        /// Максимальное значение толщины внешней стенки формы
        /// </summary>
        public const int MaxExternalWall = 10;

        /// <summary>
        /// Минимальное значение толщины внутренней стенки формы
        /// </summary>
        public const int MinInnerWall = 5;

        /// <summary>
        /// Максимальное значение толщины внутренней стенки формы
        /// </summary>
        public const int MaxInnerWall = 10;

        /// <summary>
        /// Минимальное значение толщины днища формы
        /// </summary>
        public const int MinIceMoldBottom = 5;

        /// <summary>
        /// Максимальное значение толщины днища формы
        /// </summary>
        public const int MaxIceMoldBottom = 10;

        /// <summary>
        /// Минимальное количество ячеек на ширину формы
        /// </summary>
        public const int MinCellsWidthCount = 2;

        /// <summary>
        /// Максимальное количество ячеек на ширину формы
        /// </summary>
        public const int MaxCellsWidthCount = 4;

        /// <summary>
        /// Минимальное количество ячеек на длину формы
        /// </summary>
        public const int MinCellsLengthCount = 7;

        /// <summary>
        /// Максимальное количество ячеек на длину формы
        /// </summary>
        public const int MaxCellsLengthCount = 13;

        /// <summary>
        /// Разница между длиной и шириной формы
        /// </summary>
        public const int IceMoldDifference = 150;

        /// <summary>
        /// Задаёт или возвращает общую длину формы 
        /// </summary>
        public int IceMoldLength
        {
            get => _iceMoldLength.Value;
            set
            {
                _iceMoldLength.Value = value;
                _iceMoldWidth.Value = value + IceMoldDifference;
            }
        }

        /// <summary>
        /// Задаёт или возвращает ширину формы
        /// </summary>
        public int IceMoldWidth
        {
            get => _iceMoldWidth.Value;
            set
            {
                _iceMoldWidth.Value = value;
                _iceMoldLength.Value = value - IceMoldDifference;
            }
        }

        /// <summary>
        /// Задаёт или возвращает глубину формы
        /// </summary>
        public int IceMoldDeep
        {
            get => _iceMoldDeep.Value;
            set => _iceMoldDeep.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает толщину внешней стенки
        /// </summary>
        public int ExternalWall
        {
            get => _externalWall.Value;
            set => _externalWall.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает толищну внутренней стенки
        /// </summary>
        public int InnerWall
        {
            get => _innerWall.Value;
            set => _innerWall.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает толщину днища
        /// </summary>
        public int IceMoldBottom
        {
            get => _iceMoldBottom.Value;
            set => _iceMoldBottom.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает количество ячеек на ширину формы
        /// </summary>
        public int CellsWidthCount
        {
            get => _cellsWidthCount.Value;
            set => _cellsWidthCount.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает количество ячеек на длину формы
        /// </summary>
        public int CellsLengthCount
        {
            get => _cellsLengthCount.Value;
            set => _cellsLengthCount.Value = value;
        }

        /// <summary>
        /// Конструктор класса с минимальными значенми по умолчанию
        /// </summary>
        public IceMoldParameters()
        {
            IceMoldLength = MinIceMoldLength;
            IceMoldWidth = MinIceMoldWidth;
            IceMoldDeep = MinIceMoldDeep;
            ExternalWall = MinExternalWall;
            InnerWall = MinInnerWall;
            IceMoldBottom = MinIceMoldBottom;
            CellsWidthCount = MinCellsWidthCount;
            CellsLengthCount = MinCellsLengthCount; 
        }

        /// <summary>
        /// Метод передающй значение в сеттер параметра по имени
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="value">Значение</param>
        public void SetParameterByName(IceMoldParameterType name, int value)
        {
            if (_parametersDictionary.ContainsKey(name))
            {
                switch (name)
                {
                    case IceMoldParameterType.IceMoldWidth:
                        IceMoldWidth = value;
                        break;
                    case IceMoldParameterType.IceMoldLength:
                        IceMoldLength = value;
                        break;
                    default:
                        _parametersDictionary.TryGetValue(name,
                            out var parameter);
                        parameter.Value = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Метод возвращающий значение параметра по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Значение</returns>
        public int GetParameterValueByName(IceMoldParameterType name)
        {
            _parametersDictionary.TryGetValue(name, out var parameter);
            return parameter.Value;
        }
    }
}
