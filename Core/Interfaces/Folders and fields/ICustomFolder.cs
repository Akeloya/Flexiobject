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
    /// User object folder
    /// </summary>
    public interface ICustomFolder : IBase, IEquatable<ICustomFolder>
    {
        /// <summary>
        /// Unique folder identifier
        /// <seealso cref="ISession.GetRequestFolderByUniqueId(int)"/>
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Folder name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Folder alias
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Object naming scheme inheritance flag
        /// </summary>
        bool InheritNamingScheme { get; set; }
        /// <summary>
        /// Object naming scheme
        /// <seealso cref="ICustomObject.Name"/>
        /// </summary>
        string NamingScheme { get; set; }
        /// <summary>
        /// Folder path
        /// <seealso cref="ISession.GetRequestFolderByPath(string)"/>
        /// </summary>
        string Path { get; }
        /// <summary>
        /// Collection of folder forms
        /// </summary>
        IForms Forms { get; }
        /// <summary>
        /// Parent folder link
        /// </summary>
        ICustomFolder ParentFolder { get; }                
        /// <summary>
        /// User privilegies for object and folder
        /// </summary>
        IPrivileges Privileges { get; }
        /// <summary>
        /// Folder open (select) picture
        /// </summary>
        IPicture PictureOpen { get; set; }
        /// <summary>
        /// Folder close (not select) picture
        /// </summary>
        IPicture PictureClose { get; set; }
        /// <summary>
        /// Folder objects collection
        /// </summary>
        ICustomObjects Requests { get; }
        /// <summary>
        /// Folder scrip collection
        /// </summary>
        IScripts Scripts { get; }
        /// <summary>
        /// Actions modification collection
        /// </summary>
        IActions GetActionList(CoaActionListType type);
        /// <summary>
        /// User field definition of folder
        /// </summary>
        IUserFieldDefinitions UserFieldDefinitions { get; }
        /// <summary>
        /// New filter for object of this folder
        /// </summary>
        /// <returns>IFilter object to filter ICustomObject of this folder</returns>
        IFilter MakeFilter();
        /// <summary>
        /// Nested folders
        /// </summary>
        ICustomFolders SubFolders { get; }
        /// <summary>
        /// Automatic calculation definitions for object of this folder
        /// </summary>
        IAutocalculations Autocalculations { get; }
        /// <summary>
        /// Save changes to database
        /// </summary>
        void Save();
        /// <summary>
        /// Move folder in hierarchy
        /// </summary>
        /// <param name="folder">New parent folder</param>
        void Move(ICustomFolder folder);
        /// <summary>
        /// Create empty folder column layout
        /// </summary>
        /// <returns></returns>
        IColumnLayout MakeColumnLayout();
        /// <summary>
        /// Get current column layout
        /// </summary>
        /// <returns></returns>
        IColumnLayout GetColumnLayout();
        /// <summary>
        /// Search object with filter
        /// </summary>
        /// <param name="filter">Filter for objects</param>
        /// <returns></returns>
        ICustomObjects Search(IFilter filter);
        /// <summary>
        /// Set column layout by current
        /// </summary>
        /// <param name="layout"></param>
        void SetColumnLayout(IColumnLayout layout);        
        /// <summary>
        /// Create new visual view for this folder
        /// </summary>
        /// <returns>IView object</returns>
        IView MakeView();
        /// <summary>
        /// Create new import definition
        /// </summary>
        /// <returns>Import settings object</returns>
        IImportDefinition MakeImportDefinition();
        /// <summary>
        /// Delete import settings
        /// </summary>
        /// <param name="settings">Deletion object name or IImportDefinition object</param>
        void DeleteImportDefinition(object settings);
        /// <summary>
        /// Create import from settings
        /// </summary>
        /// <returns></returns>
        IImport MakeImport();
        /// <summary>
        /// Create new query
        /// <seealso cref="IQuery"/>
        /// </summary>
        /// <returns></returns>
        IQuery MakeQuery();
        
        /// <summary>
        /// Get user privilege level for folder
        /// </summary>
        /// <param name="user">User for check privilege level</param>
        /// <returns>Privilege level <see cref="CoaEnumPrivilegeLevel"/></returns>
        CoaEnumPrivilegeLevel GetPrivilegeLevel(IUser user);
        /// <summary>
        /// Get group privilege level
        /// </summary>
        /// <param name="group">Group for check privilege level</param>
        /// <returns>Privilege level <see cref="CoaEnumPrivilegeLevel"/></returns>
        CoaEnumPrivilegeLevel GetPrivilegeLevel(IGroup group);
        /// <summary>
        /// Folder visibility rule
        /// </summary>
        IRule VisibilityRule { get; set; }
        /// <summary>
        /// Links to application objects
        /// </summary>
        /// <param name="type">Application object type</param>
        /// <returns></returns>
        bool this[CoaApplicationFolders type] { get;set; }
        /// <summary>
        /// Link application object field and user field of this folder
        /// </summary>
        /// <param name="folderType"></param>
        /// <param name="propType"></param>
        /// <returns></returns>
        IUserFieldDefinition this[CoaApplicationFolders folderType, CoaApplicationFoldersProperties propType] { get; set; }
        /// <summary>
        /// Get history changes of schema
        /// </summary>
        ISchemaHistory SchemaHistory { get; }
        /// <summary>
        /// Get or set workflow user field for history records
        /// </summary>
        IUserFieldDefinition HistoryWorkflowField { get; set; }
    }
}