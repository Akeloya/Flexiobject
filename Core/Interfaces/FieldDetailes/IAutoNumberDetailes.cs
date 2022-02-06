namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// User identifier number
    /// <seealso cref="ICustomFolder"/>
    /// <seealso cref="IUserFieldDefinition"/>
    /// </summary>
    public interface IAutoNumberDetailes : IBase
    {
        /// <summary>
        /// Field number width
        /// </summary>
        int FieldWidth { get; set; }
        /// <summary>
        /// Inherit settings from parent folder
        /// </summary>
        bool InheritSettings { get; set; }
        /// <summary>
        /// Fill zeros empty digits
        /// </summary>
        bool FillZeroes { get; set; }
        /// <summary>
        /// Initial number value
        /// </summary>
        int InitialValue { get; set; }
        /// <summary>
        /// Identifier preffix
        /// </summary>
        string Prefix { get; set; }
        /// <summary>
        /// Subfolders will get value from parent folder and won't generate own values
        /// </summary>
        bool ShareNumbersWithSubfolders { get; set; }
        /// <summary>
        /// Identifier suffix
        /// </summary>
        string Suffix { get; set; }
        /// <summary>
        /// Converting string identifier value to number
        /// </summary>
        /// <param name="value">String identifier value</param>
        /// <returns></returns>
        long ToNumber(string value);
    }
}