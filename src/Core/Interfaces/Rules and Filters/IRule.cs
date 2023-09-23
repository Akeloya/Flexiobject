using FlexiObject.Core.Enumes;
using System.Collections.Generic;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс правила фильтрования объектов
    /// </summary>
    public interface IRule : IBase
    {
        /// <summary>
        /// Комбинирование правил
        /// </summary>
        FlexiRuleComparisonsTypes? CombinationOperator { get; set; }
        /// <summary>
        /// Xml представление правила
        /// </summary>
        string Data { get; set; }
        /// <summary>
        /// Ссылка на дочерние правила
        /// </summary>
        List<IRule> ChiledRules { get; }
        /// <summary>
        /// Логическая комбинация для текущего правила или атомарное сравнение значений
        /// </summary>
        FlexiRuleCombinationTerms Combination { get; set; }
        /// <summary>
        /// Тип правого операнда
        /// </summary>
        FlexiRuleRightSideTypes RightSideType { get; set; }
        /// <summary>
        /// Тип левого операнда
        /// </summary>
        FlexiRuleLeftSideTypes LeftSideType { get; set; }
        /// <summary>
        /// Путь к полю
        /// </summary>
        string LeftSideFieldPath { get; set; }
        /// <summary>
        /// Правый операнд
        /// </summary>
        object RightSideValue { get; set; }
        /// <summary>
        /// Левый операнд
        /// </summary>
        object LeftSideValue { get; set; }
        /// <summary>
        /// Очистка правила
        /// </summary>
        void Clear();
        /// <summary>
        /// Вычисление правила
        /// </summary>
        /// <param name="request">Объект для которого вычисляется правило</param>
        /// <returns>Результат вычисления</returns>
        bool Calculate(ICustomObject request);
        /// <summary>
        /// Коллекция полей, задействованных в текущем правиле
        /// </summary>
        IUserFieldDefinitions AffectedFields { get; }
    }
}