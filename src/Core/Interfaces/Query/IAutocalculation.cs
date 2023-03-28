using System.Collections.Generic;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Автокалькуляция на папке
    /// </summary>
    public interface IAutocalculation : IBase
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Тип автокалькуляции
        /// </summary>
        FlexiSummaryTypes AutoCalculationType { get; set; }
        /// <summary>
        /// Флаги состояния модификации автокалькуляции
        /// </summary>
        FlexiExecutionFlags Flags { get; set; }
        /// <summary>
        /// Скрипт расчета
        /// </summary>
        IScript Script { get; set; }
        /// <summary>
        /// Фильтр дополнительной фильтрации объектов автокалькуляции
        /// </summary>
        IRule SummarisingFilter { get; set; }
        /// <summary>
        /// Поля хранения данных
        /// </summary>
        IUserFieldDefinitions DataStoredFields { get; set; }
        /// <summary>
        /// Поля от которых зависит расчет калькуляции скриптом
        /// </summary>
        List<string> ScriptDependencyFields { get; set; }
        /// <summary>
        /// Поле типа "ObjectList" с объектами для калькуляции
        /// <seealso cref="FlexiFieldTypes"/>
        /// <seealso cref="IUserFieldDefinition"/>
        /// <seealso cref="SummarizedFieldPath"/>
        /// </summary>
        IUserFieldDefinition ObjectsStoredField { get; set; }        
        /// <summary>
        /// Путь к полю, в котором содержатся данные
        /// </summary>
        string SummarizedFieldPath { get; set; }
        /// <summary>
        /// Хранить 0 вместо "пусто"
        /// </summary>
        bool StoreZero { get; set; }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        void Save();
        /// <summary>
        /// Пересчет автокалькуляции        
        /// </summary>
        /// <param name="variant">Объект IRequest для которого производится пересчет или IRequests для которых проводится пересчет</param>
        void Recalc(object variant);
    }
}