namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс автоинкрементного идентификатора с префиксом и постфиксом
    /// </summary>
    public interface IAutoNumberDetailes : IBase
    {
        /// <summary>
        /// Длина поля
        /// </summary>
        int FieldWidth { get; set; }
        /// <summary>
        /// Наследовать настройки (родительской папки)
        /// </summary>
        bool InheritSettings { get; set; }
        /// <summary>
        /// Заполнять нолями слева число, добивая до длины
        /// </summary>
        bool LeadingZeroes { get; set; }
        /// <summary>
        /// Максимальное значение
        /// </summary>
        int MinimumValue { get; set; }
        /// <summary>
        /// Префикс числа
        /// </summary>
        string Prefix { get; set; }
        /// <summary>
        /// Распространять на дочерние папки
        /// </summary>
        bool ShareNumbersWithSubfolders { get; set; }
        /// <summary>
        /// Суффикс авто числа
        /// </summary>
        string Suffix { get; set; }
        /// <summary>
        /// Преобразование значения авточисла в число
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        long ConvertStringToNumber(string value);
    }
}