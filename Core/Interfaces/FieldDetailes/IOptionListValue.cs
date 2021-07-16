namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Option list value
    /// </summary>
    public interface IOptionListValue : IBase
    {
        /// <summary>
        /// Alias of option list value for multilangual select
        /// </summary>
        string Alias { get; set; } 
        /// <summary>
        /// Option list value description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Option list value name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Option list value position in list
        /// </summary>
        int Position { get; }
        /// <summary>
        /// Predecessor - value lower current
        /// </summary>
        IOptionListValue Predecessor { get; }
        /// <summary>
        /// Sucessor - next value, hight current
        /// </summary>
        IOptionListValue Successor { get; }
        /// <summary>
        /// Identifier
        /// </summary>
        int UniqueId { get; }
    }
}