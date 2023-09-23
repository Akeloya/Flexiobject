using System;

namespace FlexiObject.Core.Repository
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RepositoryAttribute : Attribute
    {
        public Type Type { get; set; }
        public Type TargetType{get;set; }
        public bool WithRebind { get; set; }

        public RepositoryAttribute(Type type, Type targetType, bool withRebind = false)
        {
            Type = type;
            WithRebind = withRebind;
            TargetType = targetType;
        }
    }
}
