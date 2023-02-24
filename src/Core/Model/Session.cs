using FlexiObject.Core.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace FlexiObject.Core
{
    public class Session : AppBase, ISession
    {
        public Session(Application app): base(app, app)
        {

        }
        [JsonIgnore]//TODO: check after implement
        public ICustomFolders RequestFolders => throw new NotImplementedException();
        [JsonIgnore]
        public IActiveSessions ActiveSessions { get; }
        [JsonIgnore]//TODO: check after implement
        public string Username => throw new NotImplementedException();
        [JsonIgnore]//TODO: check after implement
        public IPictures Pictures => throw new NotImplementedException();
        [JsonIgnore]//TODO: check after implement
        public IUser ActiveUser => throw new NotImplementedException();
        [JsonIgnore]//TODO: check after implement
        public IGroups Groups => throw new NotImplementedException();
        [JsonIgnore]//TODO: check after implement
        public IUsers Users => throw new NotImplementedException();
        [JsonIgnore]//TODO: check after implement
        public IScheduledTasks ScheduledTasks => throw new NotImplementedException();

        public IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public ICustomObjects GetDeletedRequests()
        {
            throw new NotImplementedException();
        }

        public IGroup GetGroupByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public ICustomObject GetRequestByUniqueId(long id)
        {
            throw new NotImplementedException();
        }

        public ICustomFolder GetRequestFolderByPath(string path)
        {
            throw new NotImplementedException();
        }

        public ICustomFolder GetRequestFolderByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public IScript GetServerScript(string name)
        {
            throw new NotImplementedException();
        }

        public IState GetStateByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetSystemParameter(string table, string name)
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public IView GetViewByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(string msg)
        {

        }

        public void Logoff()
        {

        }

        public void NotifyUser(object reciever, string message, ICustomObject linkedRequest)
        {
            throw new NotImplementedException();
        }
    }
}
