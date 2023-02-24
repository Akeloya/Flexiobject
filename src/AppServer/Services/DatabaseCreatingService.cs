using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Services
{
    public class DatabaseCreatingService
    {
        public DatabaseCreatingService() 
        {
            var dbContext = new DbProvider.AppDbContext(new DbProvider.AppDbSettings());
        }
    }
}
