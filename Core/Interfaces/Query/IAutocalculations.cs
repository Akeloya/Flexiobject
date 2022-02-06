namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Autocalculation collection for objects in folder
    /// </summary>
    public interface IAutocalculations : IBase
    {
        /// <summary>
        /// Add new calculation
        /// </summary>
        /// <returns>Autocalculation object</returns>
        IAutocalculation Add();
        /// <summary>
        /// Remove autocalculation
        /// </summary>
        /// <param name="variant">IAutocalculation object or index</param>
        void Delete(object variant);
        /// <summary>
        /// Access to autocalculcation by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IAutocalculation this[int idx] { get; }
        /// <summary>
        /// Acces to autocalculation object by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IAutocalculation this[string name] { get; }
        /// <summary>
        /// Autocalculations count
        /// </summary>
        int Count { get; }
    }
}