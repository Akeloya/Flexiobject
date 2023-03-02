using FlexiObject.API;

using System;

using Xunit;

namespace FlexiObject.Tests.API
{
    public class SessionTests
    {
        [Fact]
        public void TestOpenCloseSession()
        {
            var api = new Api();
            var app = api.Create();
            var session = app.OpenSession("localhost", 9696, Environment.UserName, Environment.UserName);
            session.LogMessage("Test logging message from client");
            session.Logoff();
        }
    }
}
