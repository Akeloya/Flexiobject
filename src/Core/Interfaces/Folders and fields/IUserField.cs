using System.ComponentModel;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Пользовательское поле объекта
    /// </summary>
    public interface IUserField : IBase, IDataErrorInfo
    {
        /// <summary>
        /// Значение поля
        /// </summary>
        dynamic TValue { get; set; }
        /// <summary>
        /// Определение
        /// </summary>
        IUserFieldDefinition Definition { get; }
        /// <summary>
        /// Флаг отсутствия значения
        /// </summary>
        bool IsNull { get; }
        /// <summary>
        /// Доступность поля для редактирования
        /// </summary>
        bool IsEnabled { get; }
        /// <summary>
        /// Требуется ли заполнить поле
        /// </summary>
        bool IsRequired { get; }
    }
}