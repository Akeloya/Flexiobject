using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс установки сравнения для поля в правиле
    /// </summary>
    public interface IFilterFieldCompatisonIndexer
    {
        /// <summary>
        /// Установка и получение значения оператора сравнения для узла правила
        /// </summary>
        /// <param name="name">Алиас поля для которого устанавливается значение</param>
        /// <returns>NULL или тип оператора сравнения</returns>
        FlexiRuleComparisonsTypes? this[string name] { get; set; }
    }
}