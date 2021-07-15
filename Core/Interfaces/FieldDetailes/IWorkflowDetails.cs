namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Work flow
    /// </summary>
    public interface IWorkflowDetails : IBase
    {
        /// <summary>
        /// Flow states
        /// </summary>
        IStateDefinitions States { get; }
        /// <summary>
        /// States transitions
        /// </summary>
        IStateTransitions Transitions { get; }

    }
}