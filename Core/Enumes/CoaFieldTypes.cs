namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Folder field types
    /// </summary>
    public enum CoaFieldTypes : byte
    {
        /// <summary>
        /// Integer value 4 bytes
        /// </summary>
        Int,
        /// <summary>
        /// Short integer 2 bytes
        /// </summary>
        ShortInt,
        /// <summary>
        /// Long integer 8 bytes
        /// </summary>
        Bigint,
        /// <summary>
        /// Decimal field
        /// </summary>
        Decimal,
        /// <summary>
        /// User string(long) identifier field of object
        /// </summary>
        Identifier,
        /// <summary>
        /// Boolean value (true/false)
        /// </summary>
        Boolean,
        /// <summary>
        /// String field with max length 255 bytes
        /// </summary>
        String,
        /// <summary>
        /// Text field to store text with any length
        /// </summary>
        Text,
        /// <summary>
        /// Date time field
        /// </summary>
        Date,
        /// <summary>
        /// Currency field with sign
        /// </summary>
        Currency,
        /// <summary>
        /// List options to select. Allowed single selection
        /// </summary>
        OptionList,
        /// <summary>
        /// Reference to object
        /// </summary>
        Object,
        /// <summary>
        /// Object list 
        /// </summary>
        ObjectList,
        /// <summary>
        /// Field with states and transitions
        /// </summary>
        Workflow
    }
}
