namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Детали поля типа "валюта"
    /// </summary>
    public interface ICurrencyDetailes : IBase
    {
        /// <summary>
        /// Флаг отображения валютного знака
        /// </summary>
        bool SuppressCurrencySymbol { get; set; }
        /// <summary>
        /// Флаг разделения разрядов числа
        /// </summary>
        bool SuppressThousandsSeparator { get; set; }
    }
}