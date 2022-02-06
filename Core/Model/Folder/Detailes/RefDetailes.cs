using CoaApp.Core.Interfaces;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class RefDetailes : AppBase, IRefDetailes, INotifyPropertyChanged
    {
        private IUserFieldDefinitions _syncFields;
        private IUserFieldDefinition _syncField;
        private int _referencedFolderId;
        private ICustomFolder _referencedFolder;
        private bool _restriction;
        private IRule _rule;
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        /// <param name="referencedFolderId">Folder identifier</param>
        protected RefDetailes(IApplication app, object parent, int referencedFolderId) : base(app, parent)
        {
            _referencedFolderId = referencedFolderId;
        }
        ///<inheritdoc/>
        public bool CascadeCopy { get; set; }
        ///<inheritdoc/>
        public bool CascadeDelete { get; set; }
        ///<inheritdoc/>
        public ICustomFolder DefaultFolder { get; set; }
        ///<inheritdoc/>
        public IScript DefaultFolderScript { get; set; }
        ///<inheritdoc/>
        public bool DefaultFolderUseScript { get; set; }
        ///<inheritdoc/>
        public IUserFieldDefinition QuickSearchField { get; set; }
        ///<inheritdoc/>
        public bool DeleteRefObjects { get; set; }
        ///<inheritdoc/>
        public bool IncludeSubfolders { get; set; }
        ///<inheritdoc/>
        public bool IsSynchronized { get; set; }
        ///<inheritdoc/>
        public bool MasterField { get; set; }
        ///<inheritdoc/>
        public ICustomFolder ReferencedFolder
        {
            get
            {
                if (_referencedFolder == null && _referencedFolderId != 0)
                    _referencedFolder = OnGetReferencedFolder(_referencedFolderId);
                return _referencedFolder;
            }

            set
            {
                if (value == null)
                {
                    _referencedFolder = null;
                    _referencedFolderId = 0;
                }
                else
                {
                    _referencedFolder = value;
                    _referencedFolderId = _referencedFolder.UniqueId;
                }
                OnPropertyChanged();
            }
        }
        ///<inheritdoc/>
        public bool Restriction { get { return _restriction; } set { _restriction = value; OnPropertyChanged(); } }
        ///<inheritdoc/>
        public bool RestrictionOnlyForSelection { get; set; }
        ///<inheritdoc/>
        public string RestrictionOptionalErrorMessage { get; set; }
        ///<inheritdoc/>
        public IScript RestrictionScript { get; set; }
        ///<inheritdoc/>
        public IRule RestrictionRule
        {
            get
            {
                if (_rule == null)
                    _rule = OnGetEmptyRule();
                return _rule;
            }
            set { _rule = value; OnPropertyChanged(); }
        }
        ///<inheritdoc/>
        public bool RestrictionUseScript { get; set; }
        ///<inheritdoc/>
        public bool SymmetricSynchronization { get; set; }
        ///<inheritdoc/>
        public IUserFieldDefinition SynchronizedField
        {
            get
            {
                if (_syncField == null)
                {
                    _syncField = OnGetSynchField();
                }
                return _syncField;
            }
            set { _syncField = value; }
        }
        ///<inheritdoc/>
        public IUserFieldDefinitions SynchronizedFields
        {
            get
            {
                return _syncFields ??
                       (_syncFields = OnGetSynchronizedFields());
            }
            set { _syncFields = value; }
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        ///<inheritdoc/>
        public abstract ICustomFolder GetDefaultFolder();        
        ///<inheritdoc/>
        public IFilter GetRestrictionFilter()
        {
            if (Restriction)
            {
                IFilter filter = ReferencedFolder.MakeFilter();
                filter.Rule = RestrictionRule;
                return filter;
            }
            return _referencedFolder.MakeFilter();
        }
        /// <summary>
        /// Propety changed call
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        /// <summary>
        /// Realization for getting ReferencedFolder by there id
        /// </summary>
        /// <param name="folderId">Folder UniqueId value</param>
        /// <returns></returns>
        protected abstract ICustomFolder OnGetReferencedFolder(int folderId);
        /// <summary>
        /// Realization for getting object for empty restriction rule
        /// </summary>
        /// <returns></returns>
        protected abstract CoaRule OnGetEmptyRule();
        /// <summary>
        /// Realization for getting object for empty synchfield on first init
        /// </summary>
        /// <returns></returns>
        protected abstract CoaUserFieldDefinition OnGetSynchField();
        /// <summary>
        /// Realization collection of synchronized fields
        /// </summary>
        /// <returns></returns>
        protected abstract IUserFieldDefinitions OnGetSynchronizedFields();
    }
}
