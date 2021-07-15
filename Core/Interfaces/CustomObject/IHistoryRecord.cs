using System;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// ICustomObject history record
    /// </summary>
    public interface IHistoryRecord : IBase
    {
        /// <summary>
        /// Object modification action
        /// </summary>
        CoaHistoryActionTypes Action { get; }
        /// <summary>
        /// Date-time of modification
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// Description text
        /// </summary>
        string Description { get; }
        /// <summary>
        /// New value of data
        /// </summary>
        string NewValue { get; }
        /// <summary>
        /// Old value of data
        /// </summary>
        string OldValue { get; }
        /// <summary>
        /// Workflow state of object if exist field and selected on ICustomFolder
        /// </summary>
        IState State { get; }
        /// <summary>
        /// User modificated object
        /// </summary>
        IUser User { get;}
        /// <summary>
        /// Field which was modificated
        /// </summary>
        IUserFieldDefinition UserField { get; }
        /// <summary>
        /// User name who modificated object
        /// </summary>
        string UserName { get; }
    }
}