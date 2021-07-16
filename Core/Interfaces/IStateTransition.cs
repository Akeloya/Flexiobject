﻿namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Transition from state to state in workflow
    /// </summary>
    public interface IStateTransition : IBase
    {
        /// <summary>
        /// Transition from state
        /// </summary>
        IState From { get; set; }
        /// <summary>
        /// Transition to state
        /// </summary>
        IState To { get; set; }
        /// <summary>
        /// Fields, that must be with value to transition success
        /// </summary>
        IUserFieldDefinitions RequiredFields { get; set; }
        /// <summary>
        /// Actions that will be executed before transition
        /// </summary>
        IActions ActionListBefore { get; }
        /// <summary>
        /// Actions than will be executed after transition
        /// </summary>
        IActions ActionListAfter { get; }        
    }
}