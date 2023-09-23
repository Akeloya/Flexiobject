using FlexiObject.Core.Interfaces;

namespace FlexiObject.API.Model.Object
{
    public abstract class UserField: AppBase, IUserField
    {
        protected UserField(Application app, object parent) : base(app, parent)
        {

        }

        public string this[string columnName] => throw new System.NotImplementedException();

        public dynamic TValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IUserFieldDefinition Definition => throw new System.NotImplementedException();

        public bool IsNull => throw new System.NotImplementedException();

        public bool IsEnabled => throw new System.NotImplementedException();

        public bool IsRequired => throw new System.NotImplementedException();

        public string Error => throw new System.NotImplementedException();

    }
}
