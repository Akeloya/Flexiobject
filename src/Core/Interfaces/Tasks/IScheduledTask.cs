using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Запланированное серверное задание
    /// </summary>
    public interface IScheduledTask : IBase
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
        /// Расписание выполнение запланированной задачи
        /// </summary>
        ISchedule Schedule { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        FlexiScheduledTaskTypes Type { get; set; }
        /// <summary>
        /// Папка выполнения
        /// </summary>
        ICustomFolder ExecutionFolder { get; set; }
        /// <summary>
        /// Детали задания (В зависимости от типа)
        /// </summary>
        object Detailes { get; set; }
        /// <summary>
        /// Логирование результатов выполнения задания
        /// </summary>
        string ResultFileName { get; set; }
        /// <summary>
        /// Тип файла с результатами выполнения
        /// </summary>
        FlexiScheduledTaskResulFormatType ResultFileType { get; set; }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void Save();
    }
}
