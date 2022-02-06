using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    /// <inheritdoc/>
    public abstract class CustomFolder : AppBase, ICustomFolder
    {
        private int _uniqueId;
        /// <summary>
        /// Constructor for new objects
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected CustomFolder(IApplication app, object parent) : base(app, parent)
        {

        }
        /// <summary>
        /// Constructor for existing objects
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="uniqueId"></param>
        protected CustomFolder(IApplication app, object parent, int uniqueId) : base(app, parent)
        {
            _uniqueId = uniqueId;
        }
        /// <include file='commonDocs.xml' path='docs/members[@name="comparisons"]/equality/*'/>
        public static bool operator ==(CustomFolder left, ICustomFolder right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        /// <include file='commonDocs.xml' path='docs/members[@name="comparisons"]/inequality/*'/>
        public static bool operator !=(CustomFolder left, ICustomFolder right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        /// <inheritdoc/>
        public int UniqueId => _uniqueId;
        /// <inheritdoc/>
        public abstract bool this[CoaApplicationFolders type] { get; set; }
        /// <inheritdoc/>
        public abstract IUserFieldDefinition this[CoaApplicationFolders folderType, CoaApplicationFoldersProperties propType] { get; set; }
        /// <inheritdoc/>
        public abstract string Name { get; set; }
        /// <inheritdoc/>
        public abstract string Alias { get; set; }
        /// <inheritdoc/>
        public abstract bool InheritNamingScheme { get; set; }
        /// <inheritdoc/>
        public abstract string NamingScheme { get; set; }
        /// <inheritdoc/>
        public abstract string Path { get; set; }
        /// <inheritdoc/>
        public abstract IForms Forms { get; set; }
        /// <inheritdoc/>
        public abstract ICustomFolder ParentFolder { get; set; }
        /// <inheritdoc/>
        public abstract IPrivileges Privileges { get; set; }
        /// <inheritdoc/>
        public abstract IPicture PictureOpen { get; set; }
        /// <inheritdoc/>
        public abstract IPicture PictureClose { get; set; }
        /// <inheritdoc/>
        public abstract ICustomObjects Requests { get; }
        /// <inheritdoc/>
        public abstract IScripts Scripts { get; }
        /// <inheritdoc/>
        public abstract IUserFieldDefinitions UserFieldDefinitions { get; }
        /// <inheritdoc/>
        public abstract ICustomFolders SubFolders { get; }
        /// <inheritdoc/>
        public abstract IAutocalculations Autocalculations { get; }
        /// <inheritdoc/>
        public IRule VisibilityRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public abstract ISchemaHistory SchemaHistory { get; }
        /// <inheritdoc/>
        public abstract IUserFieldDefinition HistoryWorkflowField { get; set; }
        /// <inheritdoc/>
        public abstract void DeleteImportDefinition(object settings);
        /// <inheritdoc/>
        public abstract IColumnLayout GetColumnLayout();
        /// <inheritdoc/>
        public abstract IView GetInitialView(int context, int type = 0);
        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as ICustomFolder);
        }
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <inheritdoc/>
        public bool Equals(ICustomFolder other)
        {
            if (other == null)
                return false;
            return other.UniqueId == UniqueId;     
        }
        /// <inheritdoc/>
        public void Save()
        {
            _uniqueId = OnSave();
        }
        /// <inheritdoc/>
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
                if (Privileges[i].User is IGroup group)
                {
                    if (result < Privileges[i].PrivilegeLevel && user.IsInGroup(group.Name))
                        result = Privileges[i].PrivilegeLevel;
                }
            }
            return result;
        }
        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public abstract IActions GetActionList(CoaActionListType type);
        /// <inheritdoc/>
        public abstract IColumnLayout MakeColumnLayout();
        /// <inheritdoc/>
        public abstract IFilter MakeFilter();
        /// <inheritdoc/>
        public abstract IImport MakeImport();
        /// <inheritdoc/>
        public abstract IImportDefinition MakeImportDefinition();
        /// <inheritdoc/>
        public abstract IQuery MakeQuery();
        /// <inheritdoc/>
        public abstract IView MakeView();
        /// <inheritdoc/>
        public abstract void Move(ICustomFolder folder);
        /// <inheritdoc/>
        public abstract ICustomObjects Search(IFilter filter);
        /// <inheritdoc/>
        public abstract void SetColumnLayout(IColumnLayout layout);
        /// <inheritdoc/>
        public abstract void SetCurrentView(int context, int viewId);
        /// <summary>
        /// Saving method implementation
        /// </summary>
        /// <returns></returns>
        protected abstract int OnSave();
    }
}
