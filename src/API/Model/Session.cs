using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Database;

using System;
using System.Text.Json.Serialization;

namespace FlexiObject.API.Model
{
    public class Session : AppBase, ISession
    {
        private readonly IUserDbRepository _userDbRepository;
        private readonly ICustomObjectRepository _customObjectRepository;
        public Session(Application app, IUserDbRepository userDbRepo, ICustomObjectRepository customObjectRepository): base(app, app)
        {
            _userDbRepository = userDbRepo;
            _customObjectRepository = customObjectRepository;
        }
        public ICustomFolders RequestFolders => throw new NotImplementedException();
        public IActiveSessions ActiveSessions { get; }
        public string Username => throw new NotImplementedException();
        public IPictures Pictures => throw new NotImplementedException();
        public IUser ActiveUser => throw new NotImplementedException();
        public IGroups Groups => new Groups(Application, this, _userDbRepository);
        public IUsers Users => new Users(Application, this, _userDbRepository, _customObjectRepository);
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
            return _userDbRepository.GetGroup(id, this);
        }

        public ICustomObject GetRequestByUniqueId(long id)
        {
            return _customObjectRepository.GetById(id);
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
            return _userDbRepository.GetUser(id, this);
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
