namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Field mapping for import tasks
    /// </summary>
    public interface IFieldMapping : IBase
    {
        /// <summary>
        /// Source name string
        /// </summary>
        string Source { get; } 
        /// <summary>
        /// Binding user field
        /// </summary>
        IUserFieldDefinition Field { get; set; }
        /// <summary>
        /// Append to existing content (object list, text)
        /// </summary>
        bool AppendExistingContent { get; set; }
    }
}