using FlexiObject.API;

using Xunit;

namespace Core.Tests
{
    public class SessionTests
    {
        [Fact]
        public void TestOpenCloseSession()
        {
            var api = new Api();
            var app = api.Create(true);
            var session = app.OpenSession("localhost", 5555,null,null);
            session.LogMessage("Test logging message from client");
            session.Logoff();
        }
    }
}
