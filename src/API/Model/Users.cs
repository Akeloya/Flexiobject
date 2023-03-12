using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Database;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.API.Model
{
    public class Users : AppBase, IUsers
    {
        private readonly IUserRepository _dbRepository;
        private readonly ICustomObjectRepository _objRepository;
        private readonly Lazy<ICollection<IUser>> _users;
        internal Users(IApplication app, object parent, IUserRepository userDbRepository, ICustomObjectRepository objRepository, bool recursive = false) : base(app, parent)
        {
            _dbRepository = userDbRepository;
            _objRepository = objRepository;
            if (parent is IGroup group)
            {
                _users = new Lazy<ICollection<IUser>>(() => _dbRepository.GetUsers(this).ToArray());
            }

            if (parent is ISession session)
            {
                _users = new Lazy<ICollection<IUser>>(() => _dbRepository.GetUsers(this).ToArray());
            }
        }
        public IUser this[int index] => _users.Value.ElementAt(index);

        public IUser this[string name] => _users.Value.FirstOrDefault(p => p.Name == name);

        public int Count => _users.Value.Count;

        public IUser Add()
        {
            return new User(Application, this, _dbRepository, _objRepository);
        }

        public IUser GetUserByLoginName(string login)
        {
            return _dbRepository.GetUser(login, this);
        }

        public void Remove(IUser obj)
        {
            _users.Value.Remove(obj);
        }

        public void Remove(int index)
        {
            _users.Value.Remove(_users.Value.ElementAt(index));
        }
    }
}
