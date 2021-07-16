using CoaApp.Core.Enumes;
using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Application access group
    /// </summary>
    public interface IGroup : IBase, IEquatable<IGroup>
    {
        /// <summary>
        /// Group identifier
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Group name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Group displan name
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Group email address
        /// </summary>
        string EmailAddress { get; set; }
        /// <summary>
        /// Email settings behavior
        /// </summary>
        CoaGroupBehaviorTypes EmailBehavior { get; set; }
        /// <summary>
        /// Nested groups
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Nested groups recursive
        /// </summary>
        IGroups GroupsRecursive { get; }
        /// <summary>
        /// Linked ICustomObject to this groups
        /// </summary>
        ICustomObject Object { get; set; }
        /// <summary>
        /// Nested users
        /// </summary>
        IUsers Users { get; }
        /// <summary>
        /// Nested users recursive
        /// </summary>
        IUsers UsersRecursive { get; }
        /// <summary>
        /// Add nested group
        /// </summary>
        /// <param name="group">IGroup not saved object</param>
        void AddGroup(IGroup group);
        /// <summary>
        /// Add user to group
        /// </summary>
        /// <param name="user">IUser object</param>
        void AddUser(IUser user);
        /// <summary>
        /// Check group in nested groups
        /// </summary>
        /// <param name="groupName">Name checking group</param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
        /// <summary>
        /// Check group in nested group recursive
        /// </summary>
        /// <param name="groupName">Checking group name</param>
        /// <returns></returns>
        bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Remove group from nested
        /// </summary>
        /// <param name="group">IGroup object</param>
        void RemoveGroup(IGroup group);
        /// <summary>
        /// Remove user from nested
        /// </summary>
        /// <param name="user">IUser object</param>
        void RemoveUser(IUser user);
        /// <summary>
        /// Remove this group
        /// </summary>
        void Delete();
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
        /// <summary>
        /// Send e-mail to group e-mail or nested users
        /// <seealso cref="EmailAddress"/> 
        /// </summary>
        void SendEmail();
    }
}