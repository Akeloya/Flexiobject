namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Состояние рабочего процесса
    /// </summary>
    public interface IState : IBase
    {
        /// <summary>
        /// Название состояния
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Код состояния
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// Идентификатор состояния в БД
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Начальное состояние
        /// </summary>
        bool Initial { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Удаление состояния
        /// </summary>
        void Remove();
    }
}