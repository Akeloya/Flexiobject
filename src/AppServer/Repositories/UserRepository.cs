using FlexiObject.API.Model;
using FlexiObject.Core.Config;
using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;
using FlexiObject.Core.Repository.Database;
using FlexiObject.DbProvider;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.AppServer.Repositories
{
    [Repository(typeof(IUserDbRepository), typeof(UserRepository), true)]
    public class UserRepository : IUserDbRepository
    {
        private readonly AppDbContext _context;
        private readonly IContainer _container;
        public UserRepository(AppDbContext context, IContainer container)
        { 
            _context = context;
            _container = container;
        }
        public void AddGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void AddToGroup(IUser user, IGroup group)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IUser user)
        {
            Save(user);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGroup> GetGrops()
        {
            throw new NotImplementedException();
        }

        public IGroup GetGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGroup> GetGroupsByGroup(IGroup group, bool recursive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGroup> GetGroupsByUser(IUser user, bool recursive)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool IsInGroup(IUser user, string groupName, bool recursive)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromGroup(IUser user, IGroup group)
        {
            throw new NotImplementedException();
        }

        public IUser Save(IUser user)
        {
            if(user.UniqueId == 0)
            {
                var existedUser = _context.AppUsers.FirstOrDefault(p=> p.IsGroup == false && p.LoginMode == p.LoginMode && p.LoginName == p.LoginName);
                if(existedUser != null)
                    throw new ObjectAlreadyExistsException();
            }

            var dbUser = new DbProvider.Entities.AppUser
            {
                IsGroup = false,
                LoginMode = user.LoginMode,
                LoginName = user.LoginName,
                Department = user.Department,
                DisplayName = user.DisplayName,
                DomainName = user.DomainName,
                Email = user.Email,
                IsActive = true,
                IsAdministrator = user.Administrator,
                ObjectId = user.Object?.UniqueId,
                Phone = user.Phone,
                Password = user.Password,
                Modified = DateTime.Now,
            };
            _context.AppUsers.Add(dbUser);
            _context.SaveChanges();

            return new User(_container.Get<Application>(), user.Parent, this, _container.Get<ICustomObjectRepository>(), dbUser);
        }

        public IGroup Save(IGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
