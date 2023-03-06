using FlexiObject.Core.Interfaces;

using System.Collections.Generic;

namespace FlexiObject.Core.Repository.Database
{
    public interface IUserDbRepository
    {
        IEnumerable<IUser> GetUsers(object requestor);
        IEnumerable<IGroup> GetGroups(object requestor);
        IEnumerable<IGroup> GetGroupsByGroup(IGroup group, bool recursive);
        IEnumerable<IGroup> GetGroupsByUser(IUser user, bool recursive);
        IUser GetUser(int id, object requestor);
        IUser GetUser(string login, object requestor);
        IGroup GetGroup(int id, object requestor);
        void AddGroup(IGroup group);
        void AddUser(IUser user);
        void AddToGroup(IGroup group, IUser user);
        void AddToGroup(IGroup group, IGroup groupToAdd);
        void RemoveFromGroup(IGroup group, IUser user);
        void RemoveFromGroup(IGroup group, IGroup groupToRemove);
        bool IsInGroup(IUser user, string  groupName, bool recursive);
        bool IsInGroup(IGroup group, string  groupName, bool recursive);
        IUser Save(IUser user);
        IGroup Save(IGroup group);
        void Delete(int id);        
    }
}
