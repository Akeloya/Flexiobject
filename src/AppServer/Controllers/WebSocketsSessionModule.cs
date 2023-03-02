using EmbedIO.WebSockets;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Controllers
{
    internal class WebSocketsSessionModule : WebSocketModule
    {
        public WebSocketsSessionModule(string urlPath) : base(urlPath, true)
        {
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        {
            throw new NotImplementedException();
        }
    }
}
