using CoaApp.Core.Enumes;
using System;
using System.ComponentModel;

namespace CoaApp.Core
{
    /// <summary>
    /// Application folder field attribute
    /// </summary>
    public class AppFolderPropertyAttribute : Attribute
    {
        private CoaApplicationFoldersProperties _type;
        private bool _required;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Folder bype</param>
        /// <param name="required">Is folder field link required?</param>
        public AppFolderPropertyAttribute(CoaApplicationFoldersProperties type, bool required)
        {
            _type = type;
            _required = required;
        }
        /// <summary>
        /// Folder bype
        /// </summary>
        public CoaApplicationFoldersProperties Type => _type;
        /// <summary>
        /// Required folder field link
        /// </summary>
        public bool Required => _required;
        /// <summary>
        /// Identifier to store state in database
        /// </summary>
        public int Id => (int)_type;
        /// <summary>
        /// Displaing name in UI
        /// </summary>
        public string DisplayName
        {
            get
            {
                var result = string.Empty;
                var enumType = _type.GetType();
                var attributes = enumType.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null)
                    result = attributes[0].ToString();
                return result;
            }
        }
        /// <summary>
        /// Parameter name
        /// </summary>
        public string Name
        {
            get
            {
                return _type.ToString();
            }
        }
    }
}
