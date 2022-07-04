using API;

using Xunit;

namespace Core.Tests
{
    public class SessionTests
    {
        [Fact]
        public void Test1()
        {
            var app = new CoaApplication();
            var session = app.OpenSession("localhost", 5555);
            session.Logoff();
        }
    }
}
