/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using CoaApp.Core.Enumes;
using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Application user
    /// </summary>
    public interface IUser : IBase, IEquatable<IUser>
    {
        /// <summary>
        /// User object state flag. True - user allowed connect to application, false - not allowed
        /// </summary>
        bool Active { get; set; }
        /// <summary>
        /// Default custom folder for user. Uses with <see cref="HasDefaultCustomFolder"/>. This folder will show for user after open UI
        /// </summary>
        ICustomFolder DefaultCustomFolder { get; set; }        
        /// <summary>
        /// User display name
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Domain name
        /// </summary>
        string DomainName { get; set; }
        /// <summary>
        /// User e-mail address
        /// </summary>
        string EmailAddress { get; set; }
        /// <summary>
        /// Group collection containing this user object
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// All user groups
        /// </summary>
        IGroups GroupsRecursive { get; }
        /// <summary>
        /// Flag indicate default custom folder for user
        /// <see cref="DefaultCustomFolder"/>
        /// </summary>
        bool HasDefaultCustomFolder { get; set; }
        /// <summary>
        /// User Login name
        /// </summary>
        string LoginName { get; set; }
        /// <summary>
        /// Object name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// ICustomObject linked with this user object
        /// </summary>
        ICustomObject Object { get; set; }
        /// <summary>
        /// Account for outgoing e-mail
        /// </summary>
        string OutgoingEmailAccount { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Super user privilegies flag
        /// </summary>
        bool SuperUser { get; set; }
        /// <summary>
        /// Unique Id of object
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// User authentication type.
        /// </summary>
        CoaUserAuthenticationTypes AuthenticationType { get; set; }
        /// <summary>
        /// Add user object to group
        /// </summary>
        /// <param name="group">Group, which will contain this user</param>
        void AddToGroup(IGroup group);
        /// <summary>
        /// Checking whether a user belongs to a group
        /// </summary>
        /// <param name="groupName">Group name for checking</param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
        /// <summary>
        /// Recursively checking if a user belongs to a group
        /// </summary>
        /// <param name="groupName">Group name for checking</param>
        /// <returns></returns>
        bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Save object changes
        /// </summary>
        void Save();
        /// <summary>
        /// Remove object from application
        /// </summary>
        void Delete();
    }
}