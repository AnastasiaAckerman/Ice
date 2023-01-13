namespace Core
{
    /// <summary>
    /// Перечесление содержащее имена параметров
    /// </summary>
    public enum IceMoldParameterType
    {
        /// <summary>
        /// Длина формы
        /// </summary>
        IceMoldLength,

        /// <summary>
        /// Ширина формы
        /// </summary>
        IceMoldWidth,

        /// <summary>
        /// Глубина формы
        /// </summary>
        IceMoldDeep,

        /// <summary>
        /// Толщина внешних стенок
        /// </summary>
        ExternalWall,

        /// <summary>
        /// Толщина внутренних стенок
        /// </summary>
        InnerWall,

        /// <summary>
        /// Толщина днища формы
        /// </summary>
        IceMoldBottom,

        /// <summary>
        /// Количество ячеек на ширину формы
        /// </summary>
        CellsWidthCount,

        /// <summary>
        /// Количество ячеек на длину формы
        /// </summary>
        CellsLengthCount,
    }
}