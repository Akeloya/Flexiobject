using FlexiObject.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiObject.Core.Repository.Database
{
    public interface ICustomObjectRepository
    {
        public ICustomObject GetById(long id);
        public ICustomObject GetByUserId(int userId);
    }
}
