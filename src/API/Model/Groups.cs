using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Database;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.API.Model
{
    public class Groups : AppBase, IGroups
    {
        private readonly IUserDbRepository _dbRepository;
        private readonly ICustomObjectRepository _objRepo;
        private readonly Lazy<IEnumerable<IGroup>> _groups;
        internal protected Groups(IApplication app, Group parent, IUserDbRepository userRepo, ICustomObjectRepository objRepo, bool recursive = false) : base(app, parent)
        {
            _dbRepository = userRepo;
            _objRepo = objRepo;
            _groups = new Lazy<IEnumerable<IGroup>>(_dbRepository.GetGroupsByGroup(parent, recursive));
        }
        internal protected Groups(IApplication app, ISession parent, IUserDbRepository userRepo) : base(app, parent)
        {
            _dbRepository = userRepo;
            _groups = new Lazy<IEnumerable<IGroup>>(_dbRepository.GetGroups(this));
        }
        internal protected Groups(IApplication app, User parent, IUserDbRepository userRepo, bool recursive = false) : base(app, parent)
        {
            _dbRepository = userRepo;
            _groups = new Lazy<IEnumerable<IGroup>>(_dbRepository.GetGroupsByUser(parent, recursive));
        }
        public IGroup this[int idx] => _groups.Value.ElementAt(idx);

        public IGroup this[string name] => _groups.Value.FirstOrDefault(p => p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        public IGroup this[IGroup group] => _groups.Value.FirstOrDefault(p => p.UniqueId == ((Group)Parent).UniqueId);

        public int Count => _groups.Value.Count();

        public IGroup Add()
        {
            return new Group(Application, this, _dbRepository, _objRepo);
        }
    }
}
