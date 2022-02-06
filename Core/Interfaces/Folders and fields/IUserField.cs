using System.ComponentModel;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Object user field
    /// </summary>
    public interface IUserField : IBase, IDataErrorInfo, INotifyPropertyChanged
    {
        /// <summary>
        /// Field value
        /// </summary>
        dynamic TValue { get; set; }
        /// <summary>
        /// Field definition
        /// </summary>
        IUserFieldDefinition Definition { get; }
        /// <summary>
        /// Is value null flag
        /// </summary>
        bool IsNull { get; }
        /// <summary>
        /// Field avaliability for editing
        /// </summary>
        bool IsEnabled { get; }
        /// <summary>
        /// Field mandatory for value
        /// </summary>
        bool IsRequired { get; }
    }
}