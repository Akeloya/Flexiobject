using System.Collections.Generic;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Script collection
    /// </summary>
    public interface IScripts : IBase
    {
        /// <summary>
        /// Add new empty script
        /// </summary>
        /// <returns></returns>
        IScript Add();
        /// <summary>
        /// Add new script from template
        /// </summary>
        /// <param name="type">Script type. By this value choose template</param>
        /// <returns></returns>
        IScript Add(CoaScriptTypes type);
        /// <summary>
        /// Remove script by id
        /// </summary>
        /// <param name="id">Script identifier</param>
        void Remove(int id);
        /// <summary>
        /// Scripts count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access script by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IScript this [int idx] { get; }        
    }
}