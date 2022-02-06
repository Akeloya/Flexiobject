using System;

namespace CoaApp.Core
{
    /// <summary>
    /// Rule check event args
    /// </summary>
    public class CheckRuleEvents : EventArgs
    {
        /// <summary>
        /// Flag active field
        /// </summary>
        public bool EnableChangeResult { get; set; } = true;
        /// <summary>
        /// Flag field required
        /// </summary>
        public bool RequiredChangeResult { get; set; }
        /// <summary>
        /// Field alias
        /// </summary>
        public string Alias { get; }
        /// <summary>
        /// New value
        /// </summary>
        public object NewValue { get; }
        /// <summary>
        /// Old value
        /// </summary>
        public object OldValue { get; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="alias">Field alias</param>
        /// <param name="objOldValue">Old value</param>
        /// <param name="objNewVal">New value</param>
        public CheckRuleEvents(string alias, object objOldValue, object objNewVal)
        {
            Alias = alias;
            NewValue = objNewVal;
            OldValue = objOldValue;
        }
    }
}
