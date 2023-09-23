using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Фильтр данных папки
    /// </summary>
    public interface IFilter : IBase
    {
        /// <summary>
        /// Коллекция пользовательских полей для управления фильтрацией
        /// </summary>
        IFilterFieldIndexer UserField { get; }
        /// <summary>
        /// Правило фильтрации данных
        /// </summary>
        IRule Rule { get; set; }
        /// <summary>
        /// Доступ к оператору сравнения данных поля
        /// </summary>
        IFilterFieldCompatisonIndexer UserFieldComparison { get; }
        /// <summary>
        /// Папка в которой выполняется фильтрация
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// Комбинирование фильтров данных
        /// </summary>
        /// <param name="filter">Фильтр с которым комбинируется текущий фильтр</param>
        /// <param name="term">Правило комбинирования фильтра И/ИЛИ</param>
        void Combine(IFilter filter, FlexiRuleCombinationTerms term);
        /// <summary>
        /// Сохранение фильтра на сервер
        /// </summary>
        void Save();
    }
}