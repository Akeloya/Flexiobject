namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// History format value types
    /// </summary>
    public enum CoaHistoryFormatTypes
    {
        /// <summary>
        /// History record contains string value
        /// </summary>
        String,
        /// <summary>
        /// History record contains object modification data
        /// </summary>
        Object,
        /// <summary>
        /// History record contains modification for object reference
        /// </summary>
        ReferencedObject,
        /// <summary>
        /// History record contains modification for object list references
        /// </summary>
        ReferencedObjectList,
        /// <summary>
        /// History record contains modification with option list
        /// </summary>
        OptionList,
        /// <summary>
        /// History record contains changes to workflow status
        /// </summary>
        WfStatus
    }
}