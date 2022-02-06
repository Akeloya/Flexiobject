using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class WorkflowDetailes : AppBase, IWorkflowDetails
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected WorkflowDetailes(IApplication app, object parent): base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract IStateDefinitions States { get; }
        ///<inheritdoc/>
        public abstract IStateTransitions Transitions { get; }
    }
}
