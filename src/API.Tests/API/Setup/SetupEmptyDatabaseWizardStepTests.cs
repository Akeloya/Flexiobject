using FlexiObject.API.Setup;
using FlexiObject.DbProvider;

using System.Threading.Tasks;

using Xunit;

namespace FlexiObject.Tests.API.Setup
{
    public class SetupEmptyDatabaseWizardStepTests
    {
        private readonly AppDbContextFactory _appDbContextFactory;
        public SetupEmptyDatabaseWizardStepTests()
        {
            _appDbContextFactory = new AppDbContextFactory();
        }
        [Fact]
        public async Task SetupEmptyDatabaseWizardStepTest()
        {
            var step = new SetupEmptyDatabaseWizardStep(_appDbContextFactory, new FlexiObject.Core.Logging.LoggerFactory());
            await step.SetupAsync();
        }

    }
}
