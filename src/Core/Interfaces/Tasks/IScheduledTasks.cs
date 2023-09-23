namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция запланированных заданий на сервере
    /// </summary>
    public interface IScheduledTasks : IBase
    {
        /// <summary>
        /// Доступ к элементу коллекции по индексу
        /// </summary>
        /// <param name="idx">Индекс 0..Count-1</param>
        /// <returns></returns>
        IScheduledTask this[int idx] { get; }
        /// <summary>
        /// Доступ к элементу коллекции по алиасу
        /// </summary>
        /// <param name="alias">Строка - алиас запланированного задания в коллекции</param>
        /// <returns></returns>
        IScheduledTask this[string alias] { get; }
        /// <summary>
        /// Количество запланированных заданий в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Добавить новое запланированное задание
        /// </summary>
        /// <returns></returns>
        IScheduledTask Add();
        /// <summary>
        /// Удаление запланированного задания
        /// </summary>
        /// <param name="variant">Индекс или IScheduledTask объект, удаляемый с сервера</param>
        void Delete(dynamic variant);
    }
}
