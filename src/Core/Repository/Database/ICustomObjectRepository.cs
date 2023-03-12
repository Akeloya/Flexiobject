using FlexiObject.Core.Interfaces;

namespace FlexiObject.Core.Repository.Database
{
    public interface ICustomObjectRepository
    {
        public ICustomObject GetById(long id);
        public ICustomObject GetByUserOrGroupId(int userId);
    }
}
