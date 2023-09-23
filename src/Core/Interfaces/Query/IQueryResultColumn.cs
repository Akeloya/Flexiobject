using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Колонка результата запроса к данным
    /// </summary>
    public interface IQueryResultColumn : IBase
    {
        /// <summary>
        /// Название (по умолчанию Field.Label)
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Поле
        /// </summary>
        IUserFieldDefinition Field { get;}
        /// <summary>
        /// Путь к полю, которое требуется запросить.
        /// Для указания пути используется разделитель "." (точка).
        /// </summary>
        string FieldPath { get; set; }
        /// <summary>
        /// Если истина - возвращает конечные значения в виде строки, иначе - исходные значения в соответствие с типом данных
        /// </summary>
        bool AsString { get; set; }
        /// <summary>
        /// Функция аггрегирования данных
        /// </summary>
        FlexiAggregateFunctionTypes Aggregation { get; set; }
    }
}