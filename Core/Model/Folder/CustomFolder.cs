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
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    public abstract class CustomFolder : AppBase, ICustomFolder
    {
        protected CustomFolder(IApplication app, object parent) : base(app, parent)
        {

        }
        public static bool operator ==(CustomFolder left, ICustomFolder right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        public static bool operator !=(CustomFolder left, ICustomFolder right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        public bool this[CoaApplicationFolders type] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IUserFieldDefinition this[CoaApplicationFolders folderType, CoaApplicationFoldersProperties propType] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UniqueId => throw new NotImplementedException();
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Alias { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool InheritNamingScheme { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NamingScheme { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path => throw new NotImplementedException();
        public IForms Forms => throw new NotImplementedException();
        public ICustomFolder ParentFolder => throw new NotImplementedException();
        public IActions AfterCreateActions => throw new NotImplementedException();
        public IActions AfterDeleteActions => throw new NotImplementedException();
        public IActions AfterModificationActions => throw new NotImplementedException();
        public IActions BeforCreateActions => throw new NotImplementedException();
        public IActions BeforDeleteActions => throw new NotImplementedException();
        public IActions BeforModificationActions => throw new NotImplementedException();
        public IPrivileges Privileges => throw new NotImplementedException();
        public IPicture PictureOpen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPicture PictureClose { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public abstract ICustomObjects Requests { get; }
        public abstract IScripts Scripts { get; }
        public abstract IUserFieldDefinitions UserFieldDefinitions { get; }
        public abstract ICustomFolders SubFolders { get; }
        public abstract IAutocalculations Autocalculations { get; }
        public IRule VisibilityRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public abstract ISchemaHistory SchemaHistory { get; }
        public abstract IUserFieldDefinition HistoryWorkflowField { get; set; }
        public abstract void DeleteImportDefinition(object settings);
        public abstract IColumnLayout GetColumnLayout();
        public abstract IView GetInitialView(int context, int type = 0);
        public override bool Equals(object obj)
        {
            return Equals(obj as ICustomFolder);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool Equals(ICustomFolder other)
        {
            if (other == null)
                return false;
            return other.UniqueId == UniqueId;     
        }
        public CoaEnumPrivilegeLevel GetPrivilegeLevel(IUser user)
        {
            if (user == null)
                return CoaEnumPrivilegeLevel.NoPrivilege;
            if (user.SuperUser)
                return CoaEnumPrivilegeLevel.Administration;
            var result = CoaEnumPrivilegeLevel.NoPrivilege;
            for (var i = 0; i < Privileges.Count; i++)
            {
                if (Privileges[i].AllUsers)
                {
                    if (result < Privileges[i].PrivilegeLevel)
                        result = Privileges[i].PrivilegeLevel;
                    continue;
                }
                if (Privileges[i].User is IUser)
                {
                    if (result < Privileges[i].PrivilegeLevel)
                        result = Privileges[i].PrivilegeLevel;
                }
                var group = Privileges[i].User as IGroup;
                if (group != null)
                {
                    if (result < Privileges[i].PrivilegeLevel && user.IsInGroup(group.Name))
                        result = Privileges[i].PrivilegeLevel;
                }
            }
            return result;
        }
        public CoaEnumPrivilegeLevel GetPrivilegeLevel(IGroup group)
        {
            var result = CoaEnumPrivilegeLevel.NoPrivilege;
            for (var i = 0; i < Privileges.Count; i++)
                if (Privileges[i].User as CoaGroup == group)
                {
                    if (Privileges[i].AllUsers)
                    {
                        if (result < Privileges[i].PrivilegeLevel)
                            result = Privileges[i].PrivilegeLevel;
                    }

                    if (result < Privileges[i].PrivilegeLevel)
                        result = Privileges[i].PrivilegeLevel;
                }
            return result;
        }
        public abstract IColumnLayout MakeColumnLayout();
        public abstract IFilter MakeFilter();
        public abstract IImport MakeImport();
        public abstract IImportDefinition MakeImportDefinition();
        public abstract IQuery MakeQuery();
        public abstract IView MakeView();
        public abstract void Move(ICustomFolder folder);
        public abstract void Save();
        public abstract ICustomObjects Search(IFilter filter);
        public abstract void SetColumnLayout(IColumnLayout layout);
        public abstract void SetCurrentView(int context, int viewId);
    }
}
