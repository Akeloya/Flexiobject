using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Action to modificate user object
    /// <see cref="ICustomObject"/>
    /// <seealso cref="CoaActionListType"/>
    /// <seealso cref="ICustomFolder"/>
    /// </summary>
    public interface IAction : IBase
    {
        /// <summary>
        /// Action identifier
        /// </summary>
        int Id { get;}
        /// <summary>
        /// Action type
        /// </summary>
        CoaActionTypes Type { get; set; } 
        /// <summary>
        /// Action name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Action description
        /// </summary>
        string Desctiption { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        void Save();
    }
}