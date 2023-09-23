using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Задание для выполнения на сервере
    /// </summary>
    public interface ITask : IBase
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Алиас для доступа из API
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        FlexiTaskTypes Type { get; set; }
        /// <summary>
        /// Папка выполнения
        /// </summary>
        ICustomFolder ExecutionFolder { get; set; }
        /// <summary>
        /// Детали задания (В зависимости от типа)
        /// 
        /// </summary>
        object Detailes { get; set; }
        /// <summary>
        /// Запуск выполнения
        /// </summary>
        void Execute();
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void Save();
    }
}