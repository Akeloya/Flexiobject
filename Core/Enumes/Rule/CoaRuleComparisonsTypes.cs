/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
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
    /// Оператор сравнения левой и правой части булевого сравнения
    /// </summary>        
    public enum CoaRuleComparisonsTypes
    {
        /// <summary>
        /// Value is object, user, group, etc.
        /// </summary>
        Is,
        /// <summary>
        /// Value is not equal to
        /// </summary>
        IsNot,
        /// <summary>
        /// Value contains current user
        /// </summary>
        ContainsCurrentUser,
        /// <summary>
        /// Value not contains current user
        /// </summary>
        DoesNotContainCurrentUser,
        /// <summary>
        /// User or group belongs to Group
        /// </summary>
        BelongsToGroup,
        /// <summary>
        /// User or Group is not belong to group
        /// </summary>
        DoesNotBelongToGroup,
        /// <summary>
        /// Value is equal to some const
        /// </summary>
        EqualTo,
        /// <summary>
        /// Value is not equal some const
        /// </summary>
        NotEqualTo,
        /// <summary>
        /// Value is less than some const
        /// </summary>
        LessThan,
        /// <summary>
        /// Value is bigger than some const
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Value is less or equal than some const
        /// </summary>
        LessThanOrEqual,
        /// <summary>
        /// Value is bigger or equal than some const
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// Current workflow state is initial state of workflow
        /// </summary>
        IsInitialState,
        /// <summary>
        /// Current workflow state is not initial state of workflow
        /// </summary>
        IsNotInitialState,
        /// <summary>
        /// String matches some pattern
        /// </summary>
        Matches,
        /// <summary>
        /// string does not match some pattern
        /// </summary>
        DoesNotMatch,
        /// <summary>
        /// Current list value less than setted
        /// </summary>
        LessThanDropDownText,
        /// <summary>
        /// Current list value greater than setted
        /// </summary>
        GreaterThanDropDownText,
        /// <summary>
        /// Current list value less or equeal than setted
        /// </summary>
        LessThanOrEqualDropDownText,
        /// <summary>
        /// Current list value greater or equal than setted
        /// </summary>
        GreaterThanOrEqualDropDownText,
        /// <summary>
        /// Является суперпользователем
        /// </summary>
        IsSuperuser,
        /// <summary>
        /// Current environment is Windows or Linux or other applications
        /// </summary>
        IsUserClient,
        /// <summary>
        /// Current environment is API
        /// </summary>
        IsApiInterface,
        /// <summary>
        /// Current context is background process (server-side executing)
        /// </summary>
        IsBackgroundProcess,
        /// <summary>
        /// Value is user object
        /// </summary>
        IsUser,
        /// <summary>
        /// Value is group object
        /// </summary>
        IsGroup,
        /// <summary>
        /// Current user is internal user
        /// </summary>
        IsInternalUser,
        /// <summary>
        /// Current user is not internal user
        /// </summary>
        IsNotInternalUser,
        /// <summary>
        /// Setted object is visible for current user
        /// </summary>
        IsVisibleForCurrentUser,
        /// <summary>
        /// User or Group is member of Group
        /// </summary>
        IsMemberOf,
        /// <summary>
        /// User or Group is not member of Group
        /// </summary>
        IsNotMemberOf,
        /// <summary>
        /// Group contains user
        /// </summary>
        ContainsUser,
        /// <summary>
        /// Group not contains user
        /// </summary>
        NotContainsUser,
        /// <summary>
        /// Collection contains some object
        /// </summary>
        Contains,
        /// <summary>
        /// Collection not contains some object
        /// </summary>
        NotContains,
    }
}
