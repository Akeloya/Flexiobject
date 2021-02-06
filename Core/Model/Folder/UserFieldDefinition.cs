using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoaApp.Core.Model.Folder
{
    public abstract class UserFieldDefinition<T> : AppBase<T>, IUserFieldDefinition
    {
        protected UserFieldDefinition(Application app, T parent): base(app, parent)
        {

        }

        public int Id => throw new NotImplementedException();

        public string Alias { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public dynamic Details => throw new NotImplementedException();

        public CoaFieldTypes Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool WriteHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object DefaultValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanEditFieldType => throw new NotImplementedException();

        public bool UseRuleRequired { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseRuleEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRule RequiredRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRule EnabledRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IndexFieldDb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IndexField { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsEnabled(IRequest oldReq, IRequest newReq)
        {
            throw new NotImplementedException();
        }

        public bool IsRequired(IRequest oldReq, IRequest newReq)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
