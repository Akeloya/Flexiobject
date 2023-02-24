using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using System;

namespace FlexiObject.API.Model.Folder
{
    public abstract class CustomFolder: AppBase, ICustomFolder
    {
        protected CustomFolder(Application app, object parent) : base(app, parent)
        {

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

        public ICustomObjects Requests => throw new NotImplementedException();

        public IScripts Scripts => throw new NotImplementedException();

        public IUserFieldDefinitions UserFieldDefinitions => throw new NotImplementedException();

        public ICustomFolders SubFolders => throw new NotImplementedException();

        public IAutocalculations Autocalculations => throw new NotImplementedException();

        public IRule VisibilityRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISchemaHistory SchemaHistory => throw new NotImplementedException();

        public IUserFieldDefinition HistoryWorkflowField { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DeleteImportDefinition(object settings)
        {
            throw new NotImplementedException();
        }

        public IColumnLayout GetColumnLayout()
        {
            throw new NotImplementedException();
        }

        public IView GetInitialView(int context, int type = 0)
        {
            throw new NotImplementedException();
        }

        public CoaEnumPrivilegeLevel GetPrivilegeLevel(IUser user)
        {
            throw new NotImplementedException();
        }

        public CoaEnumPrivilegeLevel GetPrivilegeLevel(IGroup group)
        {
            throw new NotImplementedException();
        }

        public IColumnLayout MakeColumnLayout()
        {
            throw new NotImplementedException();
        }

        public IFilter MakeFilter()
        {
            throw new NotImplementedException();
        }

        public IImport MakeImport()
        {
            throw new NotImplementedException();
        }

        public IImportDefinition MakeImportDefinition()
        {
            throw new NotImplementedException();
        }

        public IQuery MakeQuery()
        {
            throw new NotImplementedException();
        }

        public IView MakeView()
        {
            throw new NotImplementedException();
        }

        public void Move(ICustomFolder folder)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public ICustomObjects Search(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public void SetColumnLayout(IColumnLayout layout)
        {
            throw new NotImplementedException();
        }

        public void SetCurrentView(int context, int viewId)
        {
            throw new NotImplementedException();
        }
    }
}
