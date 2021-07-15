namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Details of the text field
    /// </summary>
    public interface ITextDetails : IBase
    {
        /// <summary>
        /// Error message if string does not match regular expression
        /// </summary>
        string ErrorMessage { get; set; }
        /// <summary>
        /// Maximum field length
        /// </summary>
        int MaxSize { get; set; }
        /// <summary>
        /// Minimum field length
        /// </summary>
        int MinSize { get; set; }
        /// <summary>
        /// РRegular expression to check input
        /// </summary>
        string MustMatch { get; set; }
    }
}