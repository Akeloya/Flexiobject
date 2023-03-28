namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Детали числа
    /// </summary>
    public interface INumberDetailes : IBase
    {
        /// <summary>
        /// Разделение разрядов
        /// </summary>
         bool SuppressThousandsSeparator { get; set; }
    }
}