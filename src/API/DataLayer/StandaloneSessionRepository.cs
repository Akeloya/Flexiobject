using FlexiObject.API.Model;
using FlexiObject.Core.Config;
using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;
using FlexiObject.Core.Repository.Database;
using FlexiObject.DbProvider;

using System;
using System.Linq;

namespace FlexiObject.API.DataLayer
{
    internal class StandaloneSessionRepository : ISessionRepository
    {
        private readonly IContainer _contaner;
        private readonly AppDbContext _context;
        public StandaloneSessionRepository(IContainer contaner, AppDbContext context)
        {
            _contaner = contaner;
            _context = context;
        }
        public ISession CreateSession(string host, int port)
        {
            var users = _context.AppUsers.Where(p=> p.LoginName ==  Environment.UserName  && p.LoginMode == Core.Enumes.FlexiUserAuthTypes.Windows);
            if(!string.IsNullOrEmpty(Environment.UserDomainName))
                users = users.Where(p=> p.DomainName == Environment.UserDomainName);
            var user = users.FirstOrDefault();
            return user == null
                ? throw new UnauthorizedException()
                : (ISession)new Session(_contaner.Get<Application>(), _contaner.Get<IUserDbRepository>(), _contaner.Get<ICustomObjectRepository>());
        }

        public ISession CreateSession(string host, int port, string username, string password)
        {
            var user = _context.AppUsers.FirstOrDefault(p=> p.LoginName ==  username && p.Password == password && p.LoginMode == Core.Enumes.FlexiUserAuthTypes.Internal);
            return user == null
                ? throw new UnauthorizedException()
                : (ISession)new Session(_contaner.Get<Application>(), _contaner.Get<IUserDbRepository>(), _contaner.Get<ICustomObjectRepository>());
        }

        public void LogOff(ISession session)
        {
            session.Logoff();
        }
    }
}
