using EmbedIO.Routing;
using EmbedIO.WebApi;

using FlexiObject.Core.Transport.DataContracts;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Controllers
{
    internal class AppController : WebApiController
    {
        [Route(EmbedIO.HttpVerbs.Get, "/OpenSession")]
        public Task<PingDataContract> OpenSession(string username, string password)
        {
            return Task.FromResult(new PingDataContract());
        }
    }
}
