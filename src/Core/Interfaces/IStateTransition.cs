namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Транзакция перевода из состояния в состояние
    /// </summary>
    public interface IStateTransition : IBase
    {
        /// <summary>
        /// Состояние откуда
        /// </summary>
        IState From { get; set; }
        /// <summary>
        /// Состояние куда
        /// </summary>
        IState To { get; set; }
        /// <summary>
        /// Требуемые поля для заполнения
        /// </summary>
        IUserFieldDefinitions RequiredFields { get; set; }
        /// <summary>
        /// Действия, выполняемые до перевода
        /// </summary>
        IActions ActionListBefore { get; }
        /// <summary>
        /// Действия выполняемые после перевода
        /// </summary>
        IActions ActionListAfter { get; }
        /// <summary>
        /// Проверка правила  для объекта
        /// </summary>
        /// <param name="oldRequest">Копия объекта до изменения</param>
        /// <param name="newRequest">Копия объекта после изменения</param>
        /// <returns></returns>
        bool CheckRule(ICustomObject oldRequest, ICustomObject newRequest);
    }
}