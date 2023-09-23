using FlexiObject.DbProvider;
using FlexiObject.DbProvider.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexiObject.API.Setup.Steps
{
    internal class AddUsersStep : BaseSetupDbStep
    {
        public AddUsersStep(AppDbContext appDbContext) : base("Create application users", appDbContext)
        {
        }

        public override async Task SetupAsync()
        {
            await AppDbContext.AppUsers.AddRangeAsync(GetDefaultUsers());
            await AppDbContext.SaveChangesAsync();
        }

        private IEnumerable<AppUser> GetDefaultUsers()
        {
            var users = new LinkedList<AppUser>();
            users.AddLast(new AppUser()
            {
                LoginName = "FlexiAdmin",
                Password = "FlexiAdmin",
                IsGroup = false,
                IsAdministrator = true,
                IsActive = true,
                LoginMode = Core.Enumes.FlexiUserAuthTypes.Internal
            });
            users.AddLast(new AppUser()
            {
                LoginName = "FlexiUser",
                Password = "FlexiUser",
                IsGroup = false,
                IsAdministrator = false,
                IsActive = true,
                LoginMode = Core.Enumes.FlexiUserAuthTypes.Internal
            });
            return users;
        }
    }
}
