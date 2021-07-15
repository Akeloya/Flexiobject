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

using CoaApp.Core.Interfaces;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Event type colection modification of folder object
    /// <seealso cref="ICustomFolder"/>
    /// </summary>
    public enum CoaSchemaEventTypes : int
    {
        /// <summary>
        /// Manipulations with folder (name, naming scheme)
        /// </summary>
        Folder = 1,
        /// <summary>
        /// Manipulation with scripts
        /// <seealso cref="IScript"/>
        /// </summary>
        Script,
        /// <summary>
        /// Manipulation with autocalculations
        /// <seealso cref="IAutocalculation"/>
        /// </summary>
        Autocalculation,
        /// <summary>
        /// Manipulations with field detinitions
        /// <seealso cref="IUserFieldDefinition"/>
        /// </summary>
        FieldDefinitions,
        /// <summary>
        /// Manipulations with permissions
        /// </summary>
        Permission,
        /// <summary>
        /// Manipulations with action list
        /// <seealso cref="IAction"/>
        /// </summary>
        ActionList,
        /// <summary>
        /// Manipulations with forms
        /// <seealso cref="IForm"/>
        /// </summary>
        Form,
        /// <summary>
        /// Manipulations with form condtition        
        /// </summary>
        FormCondition,
        /// <summary>
        /// Manipulations with mappings to application folders
        /// <seealso cref="CoaApplicationFoldersProperties"/>
        /// </summary>
        AppFolderMappings,
        /// <summary>
        /// Manipulations with option list
        /// <seealso cref="IUserFieldDefinition"/>
        /// <seealso cref="IDropDownListDetailes"/>
        /// </summary>
        OptionList,
        /// <summary>
        /// Manipulations with state
        /// <seealso cref="IWorkflowDetails"/>
        /// </summary>
        State,
        /// <summary>
        /// Manipulations with stetes transitions
        /// <seealso cref="IWorkflowDetails"/>
        /// <seealso cref="IStateTransition"/>
        /// </summary>
        StateTransition,
        /// <summary>
        /// Manipulations with puctures
        /// <seealso cref="IPicture"/>
        /// </summary>
        Picture,
        /// <summary>
        /// Manipulations with application user
        /// <seealso cref="IUser"/>
        /// </summary>
        AppUser,
        /// <summary>
        /// Manipulations with application groups
        /// <seealso cref="IGroup"/>
        /// </summary>
        AppGroup,
        /// <summary>
        /// Manipulations with default value for field
        /// <seealso cref="IUserFieldDefinition"/>
        /// </summary>
        DefaultValue,
        /// <summary>
        /// Manipulations with enabled rule for field
        /// <seealso cref="IUserFieldDefinition"/>
        /// </summary>
        EnabledRule,
        /// <summary>
        /// Manipulations with required rule for field
        /// <seealso cref="IUserFieldDefinition"/>
        /// </summary>
        RequiredRule,
        /// <summary>
        /// Manipulations with restriction rule for field 'Object' or 'Object list'
        /// <seealso cref="IUserFieldDefinition"/>
        /// <seealso cref="IRefDetailes"/>
        /// </summary>
        RestrictionRule,
        /// <summary>
        /// Server version change
        /// </summary>
        ServerVersion = 2147483647
    }
}