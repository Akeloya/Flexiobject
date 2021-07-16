using System.Collections.Generic;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Automatic calculation for object on folder
    /// </summary>
    public interface IAutocalculation : IBase
    {
        /// <summary>
        /// Calculation name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Calculation type
        /// </summary>
        CoaSummaryTypes AutoCalculationType { get; set; }
        /// <summary>
        /// Autocalculation execution flags
        /// </summary>
        CoaExecutionFlags Flags { get; set; }
        /// <summary>
        /// Autocalculation script
        /// </summary>
        IScript Script { get; set; }
        /// <summary>
        /// Filter for additional filtering of autocalculated objects
        /// </summary>
        IRule SummarisingFilter { get; set; }
        /// <summary>
        /// Data storage fields
        /// Each field in which the result of the calculation is written must be specified in the collection.
        /// </summary>
        IUserFieldDefinitions DataStoredFields { get; set; }
        /// <summary>
        /// The fields on which the calculation by the script depends
        /// </summary>
        IList<string> ScriptDependencyFields { get; set; }
        /// <summary>
        /// Field definition of type "ObjectList" which stores object to calculate data
        /// <seealso cref="CoaFieldTypes"/>
        /// <seealso cref="IUserFieldDefinition"/>
        /// <seealso cref="SummarizedFieldPath"/>
        /// </summary>
        IUserFieldDefinition ObjectsStoredField { get; set; }
        /// <summary>
        /// The path to the field that contains the data
        /// </summary>
        string SummarizedFieldPath { get; set; }
        /// <summary>
        /// Store 0 instead null or empty
        /// </summary>
        bool StoreZero { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
        /// <summary>
        /// Recalc data
        /// </summary>
        /// <param name="variant">The ICustomObject or ICustomObjects for which the recalculation is performed</param>
        void Recalc(object variant);
    }
}