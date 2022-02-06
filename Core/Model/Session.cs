using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaSession : AppBase, ISession
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        protected CoaSession(CoaApplication app): base(app, app)
        {

        }
        ///<inheritdoc/>
        public abstract ICustomFolders RequestFolders { get; }
        ///<inheritdoc/>
        public abstract IActiveSessions ActiveSessions { get; }
        ///<inheritdoc/>
        public abstract string Username { get; }
        ///<inheritdoc/>
        public abstract IPictures Pictures { get; }
        ///<inheritdoc/>
        public abstract IUser ActiveUser { get; }
        ///<inheritdoc/>
        public abstract IGroups Groups { get; }
        ///<inheritdoc/>
        public abstract IUsers Users { get; }
        ///<inheritdoc/>
        public abstract IScheduledTasks ScheduledTasks { get; }
        ///<inheritdoc/>
        public abstract IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters);
        ///<inheritdoc/>
        public abstract ICustomObjects GetDeletedRequests();
        ///<inheritdoc/>
        public abstract IGroup GetGroupByUniqueId(int id);
        ///<inheritdoc/>
        public abstract ICustomObject GetRequestByUniqueId(long id);
        ///<inheritdoc/>
        public abstract ICustomFolder GetRequestFolderByPath(string path);
        ///<inheritdoc/>
        public abstract ICustomFolder GetRequestFolderByUniqueId(int id);
        ///<inheritdoc/>
        public abstract IScript GetServerScript(string name);
        ///<inheritdoc/>
        public abstract IState GetStateByUniqueId(int id);
        ///<inheritdoc/>
        public abstract string GetSystemParameter(string table, string name);
        ///<inheritdoc/>
        public abstract IUser GetUserByUniqueId(int id);
        ///<inheritdoc/>
        public abstract IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id);
        ///<inheritdoc/>
        public abstract IView GetViewByUniqueId(int id);
        ///<inheritdoc/>
        public void LogMessage(string msg)
        {
            Application.WriteLogMessage(msg);
        }
        ///<inheritdoc/>
        public abstract void Logoff();
        ///<inheritdoc/>
        public abstract void NotifyUser(object reciever, string message, ICustomObject linkedRequest);
    }
}
