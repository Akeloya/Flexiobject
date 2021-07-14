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

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Application folder properties
    /// </summary>
    public enum CoaApplicationFoldersProperties : int
    {
        #region User Accounts
        /// <summary>
        /// User login name field
        /// </summary>
        UserLoginName = 1,
        /// <summary>
        /// User display name field
        /// </summary>
        UserDisplayName = 2,
        /// <summary>
        /// Flag with superuser privilegies
        /// </summary>
        UserSuperuser = 3,
        /// <summary>
        /// User password
        /// </summary>
        UserPassword = 4,
        /// <summary>
        /// User e-mail address
        /// </summary>
        UserEmailAddress = 5,
        /// <summary>
        /// Object locked field
        /// </summary>
        UserLocked = 6,
        /// <summary>
        /// Object active field
        /// </summary>
        UserActive = 7,
        /// <summary>
        /// User authentication type
        /// </summary>
        UserAuthentication = 8,
        /// <summary>
        /// Windows domain name field value
        /// </summary>
        UserWindowsDomainName = 9,
        /// <summary>
        /// User description field
        /// </summary>
        UserDescription = 11,
        /// <summary>
        /// Last login date time value
        /// </summary>
        UserLastLogin = 12,
        #endregion

        #region User Groups
        /// <summary>
        /// Group name field
        /// </summary>
        GroupName = 31,
        /// <summary>
        /// E-mail behavior field
        /// </summary>
        GroupEmailBehavior = 32,
        /// <summary>
        /// E-mail address field
        /// </summary>
        GroupEmailAddress = 33,
        /// <summary>
        /// Nested users for group
        /// </summary>
        GroupContainedUsers = 34,
        /// <summary>
        /// Nested groups for group
        /// </summary>
        GroupContainedGroups = 35
        #endregion
    }
}