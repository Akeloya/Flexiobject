using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Privilege for a group or user associated with a folder
    /// </summary>
    public interface IPrivilege : IBase
    {
        /// <summary>
        /// Flag defining the rules for applying privileges.
        /// true - if the privilege applies to all users. Then the field <see cref="User"/> will be null
        /// false - if the privilege applies to users specified in <see cref="User"/>
        /// </summary>
        bool AllUsers { get; set; }
        /// <summary>
        /// Flag indicates inheritance of this privilege from parent folder
        /// </summary>
        bool Inherited { get; }
        /// <summary>
        /// true - if privilege is group
        /// false - privilege is user
        /// </summary>
        bool IsGroup { get; }
        /// <summary>
        /// Privilege level of user or group
        /// </summary>
        CoaEnumPrivilegeLevel PrivilegeLevel { get; set; }
        /// <summary>
        /// User or group that have this privilege
        /// Returns <see cref="IUser"/> or <see cref="IGroup"/>.
        /// </summary>
        dynamic User { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}
