using CoaApp.Core;
using CoaApp.Core.Interfaces;

namespace API
{
    public class ClntSession : CoaSession
    {
        internal ClntSession(CoaApplication app): base(app)
        {

        }

        public override ICustomFolders RequestFolders => throw new System.NotImplementedException();

        public override IActiveSessions ActiveSessions => throw new System.NotImplementedException();

        public override string Username => throw new System.NotImplementedException();

        public override IPictures Pictures => throw new System.NotImplementedException();

        public override IUser ActiveUser => throw new System.NotImplementedException();

        public override IGroups Groups => throw new System.NotImplementedException();

        public override IUsers Users => throw new System.NotImplementedException();

        public override IScheduledTasks ScheduledTasks => throw new System.NotImplementedException();

        public override IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public override ICustomObjects GetDeletedRequests()
        {
            throw new System.NotImplementedException();
        }

        public override IGroup GetGroupByUniqueId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override ICustomObject GetRequestByUniqueId(long id)
        {
            throw new System.NotImplementedException();
        }

        public override ICustomFolder GetRequestFolderByPath(string path)
        {
            throw new System.NotImplementedException();
        }

        public override ICustomFolder GetRequestFolderByUniqueId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IScript GetServerScript(string name)
        {
            throw new System.NotImplementedException();
        }

        public override IState GetStateByUniqueId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override string GetSystemParameter(string table, string name)
        {
            throw new System.NotImplementedException();
        }

        public override IUser GetUserByUniqueId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IView GetViewByUniqueId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Logoff()
        {
            throw new System.NotImplementedException();
        }

        public override void NotifyUser(object reciever, string message, ICustomObject linkedRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
