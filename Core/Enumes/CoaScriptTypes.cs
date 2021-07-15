namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Script types
    /// </summary>
    public enum CoaScriptTypes
    {
        /// <summary>
        /// Definition code
        /// </summary>
        Include,
        /// <summary>
        /// Normal code for executing in folder
        /// </summary>
        Normal,
        /// <summary>
        /// Code for filters
        /// </summary>
        Filter,
        /// <summary>
        /// Code for automatic calculations
        /// </summary>
        Autocalculation,
        /// <summary>
        /// Code for executing in scheduled tascks
        /// </summary>
        ScheduledTask,
        /// <summary>
        /// Code for executin on forms
        /// </summary>
        Form
    }
}