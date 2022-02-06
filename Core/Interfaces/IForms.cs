namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Form collection
    /// </summary>
    public interface IForms : IBase
    {
        /// <summary>
        /// Add new form
        /// </summary>
        /// <returns>New IForm object </returns>
        IForm Add();
        /// <summary>
        /// Form count in collection
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Index access form collection
        /// </summary>
        /// <param name="idx">Index 0...Count-1</param>
        /// <returns></returns>
        IForm this[int idx] { get; }
        /// <summary>
        /// Access to object in collection by name
        /// </summary>
        /// <param name="name">Form name</param>
        /// <returns></returns>
        IForm this[string name] { get; }
    }
}
