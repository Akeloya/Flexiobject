namespace CoaApp.Core.Interfaces
{
   /// <summary>
   /// Active sessions
   /// </summary>
    public interface IActiveSessions : IBase
    {
        /// <summary>
        /// Access to active session by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IActiveSession this[int idx] { get; }
        /// <summary>
        /// Active session count
        /// </summary>
        int Count { get; }
    }
}