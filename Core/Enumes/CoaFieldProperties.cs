using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Свойства пользовательского поля
    /// </summary>
    [Flags]
    public enum CoaFieldProperties
    {
        /// <summary>
        /// Нет значения по умолчанию
        /// </summary>
        NoDefaultValue = 0,
        /// <summary>
        /// Только дата
        /// </summary>
        DateOnly = 1,
        /// <summary>
        /// Значение по-умолчанию - текущая дата
        /// </summary>
        UseCurrentDateTime = 2,
        /// <summary>
        /// Значение по-умолчанию - дата создания объекта
        /// </summary>
        UseObjectCreationDateTime = 4,
        /// <summary>
        /// Используется значение по-умолчанию
        /// </summary>
        UseDefaultValue = 8,
        /// <summary>
        /// Дата не зависит от временной зоны
        /// </summary>
        TimezoneIndependent = 16
    }
}
