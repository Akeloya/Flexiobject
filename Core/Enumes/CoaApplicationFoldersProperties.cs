/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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

namespace Flexiobject.Core.Enumes
{
    /// <summary>
    /// Application folder properties
    /// </summary>
    public enum CoaApplicationFoldersProperties : int
    {
        #region User Accounts
        UserLoginName = 1,
        UserDisplayName = 2,
        UserSuperuser = 3,
        UserPassword = 4,
        UserEmailAddress = 5,
        UserLocked = 6,
        UserActive = 7,
        UserAuthentication = 8,
        UserWindowsDomainName = 9,
        UserCalendar = 10,
        UserDescription = 11,
        UserLastLogin = 12,
        UserPhone = 13,
        UserDepartment = 14,        
        #endregion

        #region User Groups
        GroupName = 31,
        GroupEmailBehavior = 32,
        GroupEmailAddress = 33,
        GroupContainedUsers = 34,
        GroupContainedGroups = 35
        #endregion
    }
}