using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Query result column
    /// </summary>
    public interface IQueryResultColumn : IBase
    {
        /// <summary>
        /// Column name (by default Field.Label)
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// User field
        /// </summary>
        IUserFieldDefinition Field { get;}
        /// <summary>
        /// The path to the field you want to query
        /// Field path delimeter "." (point).
        /// </summary>
        string FieldPath { get; set; }
        /// <summary>
        /// If true - returns the final values as a string, otherwise - the initial values according to the data type
        /// </summary>
        bool AsString { get; set; }
        /// <summary>
        /// Data aggregation function
        /// </summary>
        CoaAggregateFunctionTypes Aggregation { get; set; }
    }
}