using AppServer.Model;
using System;
using Xunit;

namespace AppServerTests
{
    public class Initialization : IClassFixture<ServerFixture>
    {
        private ServerFixture _fixture;

        public Initialization(ServerFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void Initialize()
        {
            var session = _fixture.GetSession();
            session.Logoff();            
        }
    }
}
