using FlexiObject.Core.Interfaces;

using System.Collections.Generic;

namespace FlexiObject.Core.Repository.Database
{
    public interface IUserDbRepository
    {
        IEnumerable<IUser> GetUsers();
        IEnumerable<IGroup> GetGrops();
        IEnumerable<IGroup> GetGroupsByGroup(IGroup group, bool recursive);
        IEnumerable<IGroup> GetGroupsByUser(IUser user, bool recursive);
        IUser GetUser(int id);
        IGroup GetGroup(int id);
        void AddGroup(IGroup group);
        void AddUser(IUser user);
        void AddToGroup(IUser user, IGroup group);
        void RemoveFromGroup(IUser user, IGroup group);
        bool IsInGroup(IUser user, string  groupName, bool recursive);
        IUser Save(IUser user);
        IGroup Save(IGroup group);
        void Delete(int id);        
    }
}
