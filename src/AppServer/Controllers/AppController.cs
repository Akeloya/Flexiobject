using EmbedIO.Routing;
using EmbedIO.WebApi;

using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Repository.Database;
using FlexiObject.Core.Transport.DataContracts;

using System.Threading.Tasks;

namespace FlexiObject.AppServer.Controllers
{
    internal class AppController : WebApiController
    {
        private readonly IUserRepository _userRepository;
        public AppController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route(EmbedIO.HttpVerbs.Get, "/OpenSession")]
        public async Task<PingDataContract> OpenSession([QueryField]string username, [QueryField]string password, [QueryField]string domain)
        {
            if(!_userRepository.TestLogin(username, password, domain))
                throw new UnauthorizedException();

            return new PingDataContract();
        }
    }
}
