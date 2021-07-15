using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Field definition detales for type 'Date'
    /// <seealso cref="IUserFieldDefinition"/>
    /// <seealso cref="CoaFieldTypes"/>
    /// </summary>
    public interface IDateDetailes : IBase
    {
        /// <summary>
        /// Default value of field will be object creation date-time
        /// </summary>
        bool CreationDateAsDefault { get; set; }
        /// <summary>
        /// Current date-time will be value of field
        /// </summary>
        bool CurrentDateTime { get; set; }
        /// <summary>
        /// Only date, time part will be 00:00:00
        /// </summary>
        bool DateOnly { get; set; }
        /// <summary>
        /// Time zone independent
        /// </summary>
        bool TimezoneIndependent { get; set; }
    }
}