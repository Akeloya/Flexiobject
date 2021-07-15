namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Email message send parameters
    /// </summary>
    public enum CoaGroupBehaviorTypes
    {
        /// <summary>
        /// E-mail won't be sended
        /// </summary>
        NoSend = 0,
        /// <summary>
        /// E-mail will be sended to mail address setted in field of group object
        /// </summary>
        SendToGroupEmail,
        /// <summary>
        /// E-mail will be sended to each user email address
        /// </summary>
        SendToUsersEmail
    }
}