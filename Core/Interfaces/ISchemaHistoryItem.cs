using System;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Schema history changes item
    /// </summary>
    public interface ISchemaHistoryItem : IBase
    {
        /// <summary>
        /// Event date
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// Event type
        /// </summary>
        CoaSchemaEventTypes Type { get; }
        /// <summary>
        /// Reference identifier for linked object
        /// </summary>
        int Reference { get; }
        /// <summary>
        /// User name
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Identifier of deleted object
        /// </summary>
        int DeletedRef { get; }
        /// <summary>
        /// Old string value
        /// </summary>
        string OldStrValue { get; }
        /// <summary>
        /// New string value
        /// </summary>
        string NewStringVal { get; }
        /// <summary>
        /// Action change on object
        /// </summary>
        CoaSchemaActionTypes Action { get; }
        /// <summary>
        /// Server version
        /// </summary>
        string Version { get; }
        /// <summary>
        /// The network address from which the change was made
        /// </summary>
        string IPAddress { get; }
    }
}
