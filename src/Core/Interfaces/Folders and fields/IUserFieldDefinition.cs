using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Определение пользовательского поля
    /// </summary>
    public interface IUserFieldDefinition : IBase
    {
        /// <summary>
        /// Ид определения
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Алиас определения
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Название пользовательского определения
        /// </summary>
        string Label { get; set; }
        /// <summary>
        /// Детали пользовательского определения
        /// </summary>
        dynamic Details { get; }
        /// <summary>
        /// Тип пользовательского определения
        /// </summary>
        FlexiFieldTypes Type { get; set; }
        /// <summary>
        /// Необходимость записывать в историю изменения значения поля объекта
        /// </summary>
        bool WriteHistory { get; set; }
        /// <summary>
        /// Значение по умолчанию. Для даты подробности получения значения по умолчанию определяются в деталях
        /// </summary>
        object DefaultValue { get; set; }
        /// <summary>
        /// Вычисление необходимости установить значение в поле
        /// </summary>
        /// <param name="oldReq">Копия объекта до изменения</param>
        /// <param name="newReq">Копия объекта после изменения</param>
        /// <returns>истина/ложь</returns>
        bool IsRequired(ICustomObject oldReq, ICustomObject newReq);
        /// <summary>
        /// Доступно ли поле для использования
        /// </summary>
        /// <param name="oldReq"></param>
        /// <param name="newReq"></param>
        /// <returns></returns>
        bool IsEnabled(ICustomObject oldReq, ICustomObject newReq);
        /// <summary>
        /// Возможна ли смена типа поля
        /// </summary>
        bool CanEditFieldType { get; }
        /// <summary>
        /// Необходим ли использовать правило обязательности заполнения данных
        /// </summary>
        bool UseRuleRequired { get; set; }
        /// <summary>
        /// Доступно ли поле для редактирования
        /// </summary>
        bool UseRuleEnabled { get; set; }
        /// <summary>
        /// Правило обязательности заполнения
        /// </summary>
        IRule RequiredRule { get; set; }
        /// <summary>
        /// Правило доступности редактирования
        /// </summary>
        IRule EnabledRule { get; set; }
        /// <summary>
        /// Индекс в БД
        /// </summary>
        bool IndexFieldDb { get; set; }
        /// <summary>
        /// Индекс поля
        /// </summary>
        bool IndexField { get; set; }
        /// <summary>
        /// Сохранение измений
        /// </summary>
        void Save();
    }
}