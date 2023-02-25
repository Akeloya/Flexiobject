using FlexiObject.API;

using Xunit;

namespace FlexiObject.Tests.Core
{
    public class SessionTests
    {
        [Fact]
        public void TestOpenCloseSession()
        {
            var api = new Api(true);
            var app = api.Create();
            var session = app.OpenSession("localhost", 5555, null, null);
            session.LogMessage("Test logging message from client");
            session.Logoff();
        }
    }
}
