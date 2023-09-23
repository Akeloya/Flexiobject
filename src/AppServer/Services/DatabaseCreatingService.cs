using FlexiObject.Core.Enumes;
using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Logging;
using FlexiObject.DbProvider;
using FlexiObject.DbProvider.Entities;

using System;
using System.Linq;

namespace FlexiObject.AppServer.Services
{
    public class DatabaseCreatingService
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        private readonly IApplication _application;
        private const string AdminLogin = "Administrator";
        public DatabaseCreatingService(AppDbContext context, LoggerFactory loggerFactory, IApplication application)
        {
            _context = context;
            _logger = loggerFactory.Create<DatabaseCreatingService>();
            _application = application;
        }

        public void CreateEmptyDatabase(string adminPassword)
        {
            var userTableCount = _context.AppTableDefinitions.Count();
            var userFieldCount = _context.AppFieldDefinitions.Count();
            var userObjCount = _context.ObjectDef.Count();

            _logger.Trace($"Table count {userTableCount}, field count: {userFieldCount}, user object count {userObjCount}");
            if (userTableCount > 0 || userFieldCount > 0 || userObjCount > 0)
                throw new DatabaseNotEmptyException();

            var result = _context.Database.EnsureCreated();
            _logger.Info($"EnshureCreated result: {result}");

            AddUsers(adminPassword);

            AddUserFolders(adminPassword);
        }

        private void AddUsers(string adminPassword)
        {
            var systemUser = new AppUser
            {
                DisplayName = "System",
                Id = int.MaxValue,
                IsGroup = false,
                Modified = DateTime.Now,
                LoginMode = FlexiUserAuthTypes.NoAuth,
                LoginName = "System",
                IsActive = false,
                IsAdministrator = true
            };

            var adminUser = new AppUser
            {
                DisplayName = AdminLogin,
                LoginName = AdminLogin,
                Password = adminPassword, //TODO: store secure
                Modified = DateTime.Now,
                Id = 1,
                IsGroup = false,
                LoginMode = FlexiUserAuthTypes.Internal,
                IsActive = true,
                IsAdministrator = true
            };

            _context.AppUsers.Add(systemUser);
            _context.AppUsers.Add(adminUser);
            _context.SaveChanges();

            _logger.Trace("Users added");

            adminUser.ObjectId = AddUserFolders(adminPassword);
            _context.SaveChanges();
        }

        private long AddUserFolders(string userPassword)
        {
            const string DisplayName = "Display name";
            const string Login = "Login";
            const string Password = "Password";
            const string IsActive = "Is Active";
            const string IsAdmin = "Is Admin";

            var session = _application.OpenSession("localhost", 0, AdminLogin, userPassword);

            var userFolder = session.RequestFolders.Add("Users", "USERS", session.GetRequestFolderByUniqueId(int.MaxValue));
            userFolder.Save();

            var displayNameField = userFolder.UserFieldDefinitions.Add(FlexiFieldTypes.String);
            displayNameField.Alias = displayNameField.Label = DisplayName;
            displayNameField.Save();

            var loginField = userFolder.UserFieldDefinitions.Add(FlexiFieldTypes.String);
            loginField.Alias = loginField.Label = Login;
            loginField.Save();

            var passwordField = userFolder.UserFieldDefinitions.Add(FlexiFieldTypes.String);
            passwordField.Alias = passwordField.Label = Password;
            passwordField.Save();

            var isActiveField = userFolder.UserFieldDefinitions.Add(FlexiFieldTypes.Boolean);
            isActiveField.Alias = isActiveField.Label = IsActive;
            isActiveField.DefaultValue = true;
            isActiveField.Save();

            var isAdminField = userFolder.UserFieldDefinitions.Add(FlexiFieldTypes.Boolean);
            isAdminField.Alias = isAdminField.Label = IsAdmin;
            isAdminField.DefaultValue = true;
            isAdminField.Save();

            userFolder[FlexiApplicationFolders.UserAccounts, FlexiApplicationFoldersProperties.UserDisplayName] = displayNameField;
            userFolder[FlexiApplicationFolders.UserAccounts, FlexiApplicationFoldersProperties.UserLoginName] = loginField;
            userFolder[FlexiApplicationFolders.UserAccounts, FlexiApplicationFoldersProperties.UserActive] = isActiveField;
            userFolder[FlexiApplicationFolders.UserAccounts, FlexiApplicationFoldersProperties.UserIsAdministrator] = isAdminField;
            userFolder.Save();

            var userObj = userFolder.Requests.Add();
            userObj.UserFields[DisplayName].TValue = AdminLogin;
            userObj.UserFields[Login].TValue = AdminLogin;
            userObj.UserFields[IsActive].TValue = true;
            userObj.UserFields[IsAdmin].TValue = IsAdmin;
            userObj.Save();

            return userObj.UniqueId;
        }
    }
}
