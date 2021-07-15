using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    /// <inheritdoc/>
    public abstract class CurrencyDetailes : AppBase, ICurrencyDetailes
    {
        /// <inheritdoc/>
        public bool CurrencySymbol { get; set; }
        /// <inheritdoc/>
        public bool ThousandsSeparator { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app">Application reference</param>
        /// <param name="parent">Parent object</param>
        /// <param name="currency">Currency flag</param>
        /// <param name="thousands">Thousand separator flag</param>
        protected CurrencyDetailes(IApplication app, object parent, bool currency, bool thousands): base(app, parent)
        {
            ThousandsSeparator = thousands;
            CurrencySymbol = currency;
        }
    }
}
