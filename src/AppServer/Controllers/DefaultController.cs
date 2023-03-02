using EmbedIO.Routing;
using EmbedIO.WebApi;

using FlexiObject.Core.Transport.DataContracts;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Controllers
{
    internal class DefaultController : WebApiController
    {
        [Route(EmbedIO.HttpVerbs.Get, "/ping")]
        public Task<PingDataContract> Ping()
        {
            return Task.FromResult(new PingDataContract
            {
                DateTime = DateTime.Now,
                ServerInfo = "test server info",
                Version = "some version"
            });
        }
    }
}
