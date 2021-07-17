using System;
using CoaApp.Core.Enumes;
using System.ComponentModel;

namespace CoaApp.Core.Model.ApplicationFolders
{
    /// <summary>
    /// An attribute that specifies for a class its application folder type
    /// </summary>
    public class AppFolderAttribute : Attribute
    {
        private CoaApplicationFolders _type;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Application folder type</param>
        public AppFolderAttribute(CoaApplicationFolders type)
        {
            _type = type;
        }
        /// <summary>
        /// Application folder type
        /// </summary>
        public CoaApplicationFolders Type => _type;
        /// <summary>
        /// Identity for store in database
        /// </summary>
        public int Id => (int)_type;
        /// <summary>
        /// Displan name in UI
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
    }
}
