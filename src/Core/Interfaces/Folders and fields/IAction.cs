using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Действие выполняющееся автоматически при создании, изменении или удалении объекта
    /// </summary>
    public interface IAction : IBase
    {
        /// <summary>
        /// Ид действия
        /// </summary>
        int Id { get;}
        /// <summary>
        /// Тип действия
        /// </summary>
        FlexiActionTypes Type { get; set; } 
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Desctiption { get; set; }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        /// <returns></returns>
        void Save();
    }
}