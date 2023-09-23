namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Детали поля типа "дата"
    /// </summary>
    public interface IDateDetailes : IBase
    {
        /// <summary>
        /// Дата создания в качестве значения по умолчанию
        /// </summary>
        bool CreationDateAsDefault { get; set; }
        /// <summary>
        /// Текущее время в качестве значения по умолчанию
        /// </summary>
        bool CurrentDateTime { get; set; }
        /// <summary>
        /// Только дата
        /// </summary>
        bool DateOnly { get; set; }
        /// <summary>
        /// Независимо от временной зоны
        /// </summary>
        bool TimezoneIndependent { get; set; }
    }
}