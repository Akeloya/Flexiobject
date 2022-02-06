namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Number detailes
    /// </summary>
    public interface INumberDetailes : IBase
    {
        /// <summary>
        /// Show/hide thousands separator
        /// </summary>
        bool ThousandsSeparator { get; set; }
    }
}