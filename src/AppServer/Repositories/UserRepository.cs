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

        public void AddToGroup(IGroup group, IUser user)
        {
            throw new NotImplementedException();
        }

        public void AddToGroup(IGroup group, IGroup groupAddTo)
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

        public IEnumerable<IGroup> GetGroups(object requestor)
        {
            var app = _container.Get<IApplication>();
            var objRepo = _container.Get<ICustomObjectRepository>();
            return _context.AppUsers.Where(p=> p.IsGroup == true).Select(p=> new Group(app, requestor, this, objRepo, p));
        }

        public IGroup GetGroup(int id, object requestor)
        {
            var dbGroup = _context.AppUsers.FirstOrDefault(x => x.Id == id && x.IsGroup == false);
            return dbGroup == null
                ? throw new ObjectNotFoundException()
                : (IGroup)new Group(_container.Get<IApplication>(), requestor, this, _container.Get<ICustomObjectRepository>(), dbGroup);
        }

        public IEnumerable<IGroup> GetGroupsByGroup(IGroup group, bool recursive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGroup> GetGroupsByUser(IUser user, bool recursive)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int id, object requestor)
        {
            var dbUser = _context.AppUsers.FirstOrDefault(x => x.Id == id && x.IsGroup == false);
            return dbUser == null
                ? throw new ObjectNotFoundException()
                : (IUser)new User(_container.Get<IApplication>(), requestor, this, _container.Get<ICustomObjectRepository>(), dbUser);
        }

        public IEnumerable<IUser> GetUsers(object requestor)
        {
            var app = _container.Get<IApplication>();
            var objRepo = _container.Get<ICustomObjectRepository>();
            return _context.AppUsers.Where(p=> p.IsGroup == false && p.Id != int.MinValue).Select(p=> new User(app, requestor, this, objRepo, p));
        }

        public bool IsInGroup(IUser user, string groupName, bool recursive)
        {
            throw new NotImplementedException();
        }

        public bool IsInGroup(IGroup group, string groupName, bool recursive)
        {
            throw new NotImplementedException();
        }
        public void RemoveFromGroup(IGroup group, IUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromGroup(IGroup group, IGroup removingGroup)
        {
            throw new NotImplementedException();
        }

        public IUser Save(IUser user)
        {
            if (user.UniqueId == 0)
            {
                var existedUser = _context.AppUsers.FirstOrDefault(p => p.IsGroup == false && p.LoginMode == p.LoginMode && p.LoginName == p.LoginName);
                if (existedUser != null)
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
                Id = user.UniqueId
            };
            if(user.UniqueId == 0)
                _context.AppUsers.Add(dbUser);
            else
                _context.AppUsers.Attach(dbUser);
            _context.SaveChanges();

            return new User(_container.Get<Application>(), user.Parent, this, _container.Get<ICustomObjectRepository>(), dbUser);
        }

        public IGroup Save(IGroup group)
        {
            var dbUser = new DbProvider.Entities.AppUser
            {
                Id = group.UniqueId,
                IsGroup = true,
                DisplayName = group.DisplayName,
                Email = group.EmailAddress,
                IsActive = true,
                ObjectId = group.Object?.UniqueId,
                Modified = DateTime.Now
            };
            if(group.UniqueId == 0)
                _context.AppUsers.Add(dbUser);
            else
                _context.AppUsers.Attach(dbUser);
            _context.SaveChanges();

            return new Group(_container.Get<Application>(), group.Parent, this, _container.Get<ICustomObjectRepository>(), dbUser);
        }

        public IUser GetUser(string login, object requestor)
        {
            var dbUser = _context.AppUsers.FirstOrDefault(p => p.LoginName == login && p.IsGroup == false);
            return dbUser == null
                ? throw new ObjectNotFoundException()
                : (IUser)new User(_container.Get<IApplication>(), requestor, this, _container.Get<ICustomObjectRepository>(), dbUser);
        }
    }
}
