namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// View objects interface
    /// Contains filter object and view layout
    /// </summary>
    public interface IView : IBase
    {
        /// <summary>
        /// View description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Objects filter
        /// </summary>
        IFilter Filter { get; set; }
        /// <summary>
        /// View laoyut
        /// </summary>
        IViewLayout Layout { get; set; }
        /// <summary>
        /// View name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Public view or private
        /// </summary>
        bool Public { get; set; }
        /// <summary>
        /// Unique id of view
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Rule show/hide view
        /// </summary>
        IRule VisibilityRule { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="overwrite">Overwrite changes</param>
        void Save(bool overwrite = false);
    }
}