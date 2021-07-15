using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// The interface for setting a comparison for a field in a rule
    /// </summary>
    public interface IFilterFieldCompatisonIndexer
    {
        /// <summary>
        /// Setting and Retrieving the Value of the Comparison Operator for the Rule Node
        /// </summary>
        /// <param name="name">Alias of the field for which the value is set</param>
        /// <returns>NULL or type of comparison operator</returns>
        CoaRuleComparisonsTypes? this[string name] { get; set; }
    }
}