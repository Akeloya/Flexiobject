namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Рабочий процесс
    /// </summary>
    public interface IWorkflowDetails : IBase
    {
        /// <summary>
        /// Состояния рабочего процесса
        /// </summary>
        IStateDefinitions States { get; }
        /// <summary>
        /// Допустимые переводы рабочего процесса
        /// </summary>
        IStateTransitions Transitions { get; }

    }
}