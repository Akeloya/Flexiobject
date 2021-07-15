using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Field detailes of type "Currency"
    /// <seealso cref="CoaFieldTypes"/>
    /// </summary>
    public interface ICurrencyDetailes : IBase
    {
        /// <summary>
        /// Flag to display currency symbol
        /// </summary>
        bool CurrencySymbol { get; set; }
        /// <summary>
        /// Flag to display thousands separator
        /// </summary>
        bool ThousandsSeparator { get; set; }
    }
}