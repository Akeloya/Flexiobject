using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Filter data in objects
    /// </summary>
    public interface IFilter : IBase
    {
        /// <summary>
        /// User field for filter data
        /// </summary>
        IFilterFieldIndexer UserField { get; }
        /// <summary>
        /// Filtering rule
        /// </summary>
        IRule Rule { get; set; }
        /// <summary>
        /// User field comparison
        /// </summary>
        IFilterFieldCompatisonIndexer UserFieldComparison { get; }
        /// <summary>
        /// Folder of filter
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// Combining two filter in one
        /// </summary>
        /// <param name="filter">The filter with which the current filter is combined</param>
        /// <param name="term">Filter combination rule AND / OR</param>
        void Combine(IFilter filter, CoaRuleCombinationTerms term);
        /// <summary>
        /// Save filter
        /// </summary>
        void Save();
    }
}