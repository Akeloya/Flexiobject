using FlexiObject.API.Model;
using FlexiObject.API.Transport;
using FlexiObject.Core;
using FlexiObject.Core.Interfaces;

using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace API
{
    public class CoaSession : Session
    {
        private readonly Client _client;
        [NonSerialized]
        private readonly Lazy<IActiveSessions> _activeSessions;
        internal CoaSession(CoaApplication app, Client client): base(app)
        {
            _client = client;
            _activeSessions = new Lazy<IActiveSessions>(() => new CoaActiveSessions(app, this));
        }
        [JsonIgnore]
        public override IActiveSessions ActiveSessions => _activeSessions.Value;

        public override void LogMessage(string msg)
        {
            CallServer(parameters: msg);
        }

        public override void Logoff()
        {
            CallServer();
        }

        protected void CallServer([CallerMemberName] string method = null, params object[] parameters)
        {
            _client.CallServer(this, method, parameters);
        }
    }
}
