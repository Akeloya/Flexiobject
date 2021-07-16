namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// State in flow
    /// </summary>
    public interface IState : IBase
    {
        /// <summary>
        /// Multilangual state title
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// State code
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// State identifier
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Initial state flage. Can be one in flow
        /// </summary>
        bool Initial { get; set; }
        /// <summary>
        /// State description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Removing state from flow
        /// </summary>
        void Remove();
    }
}