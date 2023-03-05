using EmbedIO.Routing;
using EmbedIO.WebApi;

using FlexiObject.Core.Transport.DataContracts;
using FlexiObject.DbProvider;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace FlexiObject.AppServer.Controllers
{
    internal class AppController : WebApiController
    {
        private readonly AppDbContext _context;
        public AppController(AppDbContext context)
        {
            _context = context;
        }
        [Route(EmbedIO.HttpVerbs.Get, "/OpenSession")]
        public async Task<PingDataContract> OpenSession([QueryField]string username, [QueryField]string password)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(p=> p.LoginName == username && p.Password == password && p.LoginMode == Core.Enumes.FlexiUserAuthTypes.Internal);
            if (user != null)
            {
                return new PingDataContract();
            }
            return null;
        }
    }
}
