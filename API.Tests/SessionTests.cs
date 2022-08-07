using API;

using Xunit;

namespace Core.Tests
{
    public class SessionTests
    {
        [Fact]
        public void TestOpenCloseSession()
        {
            var app = new CoaApplication();
            var session = app.OpenSession("localhost", 5555);
            session.LogMessage("Test logging message from client");
            session.Logoff();
        }
    }
}
