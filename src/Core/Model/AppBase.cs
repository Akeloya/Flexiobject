using FlexiObject.Core.Interfaces;
using System;

namespace FlexiObject.Core
{
    [Serializable]
    public abstract class AppBase : MarshalByRefObject, IBase
    {
        public AppBase(IApplication app, object parent)
        {
            Application = app;
            Parent = parent;
        }

        /// <summary>
        /// Never dismount in domains
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public IApplication Application { get; }

        public object Parent { get; }

        protected string GetName(int objectId, string namingSchema)
        {
            if(!string.IsNullOrWhiteSpace(namingSchema))
            {
                return $"Объект {objectId} схема именования не реализована";
            }
            return $"Объект {objectId}";
        }
    }
}
