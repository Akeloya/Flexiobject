namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Application folder properties
    /// </summary>
    public enum FlexiApplicationFoldersProperties : int
    {
        #region User Accounts
        UserLoginName = 1,
        UserDisplayName = 2,
        UserIsAdministrator = 3,
        UserPassword = 4,
        UserEmailAddress = 5,
        UserLocked = 6,
        UserActive = 7,
        UserAuthentication = 8,
        UserWindowsDomainName = 9,
        UserCalendar = 10,
        UserDescription = 11,
        UserLastLogin = 12,
        UserPhone = 13,
        UserDepartment = 14,        
        #endregion

        #region User Groups
        GroupName = 31,
        GroupEmailBehavior = 32,
        GroupEmailAddress = 33,
        GroupContainedUsers = 34,
        GroupContainedGroups = 35
        #endregion
    }
}