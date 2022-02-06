using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class StateTransition: AppBase, IStateTransition
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected StateTransition(IApplication app, object parent): base(app, parent)
        {

        }
        ///<inheritdoc/>
        public IState From { get; set; }
        ///<inheritdoc/>
        public IState To { get; set; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinitions RequiredFields { get; set; }
        ///<inheritdoc/>
        public abstract IActions ActionListBefore { get; }
        ///<inheritdoc/>
        public abstract IActions ActionListAfter { get; }
        ///<inheritdoc/>
        public abstract bool CheckRule(CoaCustomObject oldObj, CoaCustomObject newObj);
    }
}
