using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    /// <summary>
    /// Application base class
    /// </summary>
    public abstract class AppBase : MarshalByRefObject, IBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected AppBase(IApplication app, object parent)
        {
            Application = app;
            Parent = parent;
        }
#pragma warning disable CS0672
        /// <summary>
        /// Never dismount in domains
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
#pragma warning restore CS0672
        ///<inheritdoc/>
        public IApplication Application { get; }
        ///<inheritdoc/>
        public object Parent { get; }
    }
}
