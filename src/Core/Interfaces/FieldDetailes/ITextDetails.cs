namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Детали текстового поля
    /// </summary>
    public interface ITextDetails : IBase
    {
        /// <summary>
        /// Сообщение об ошибке, если строка не совпадает с регулярным выражением
        /// </summary>
        string ErrorMessage { get; set; }
        /// <summary>
        /// Максимальная длина поля
        /// </summary>
        int MaxSize { get; set; }
        /// <summary>
        /// Минимальная длина поля
        /// </summary>
        int MinSize { get; set; }
        /// <summary>
        /// Регулярное выражение
        /// </summary>
        string MustMatch { get; set; }
    }
}