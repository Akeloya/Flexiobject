using CoaApp.Core.Enumes;
using System.Drawing;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Application form
    /// </summary>
    public interface IForm : IBase
    {
        /// <summary>
        /// Form name (short name)
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Form title, multilangual
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Window (form) width
        /// </summary>
        double Width { get; set; }
        /// <summary>
        /// Window (form) height
        /// </summary>
        double Height { get; set; }
        /// <summary>
        /// Form content (xaml markup)
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// Form background
        /// </summary>
        Color? Background { get; set; }
        /// <summary>
        /// Forlder form, if form global - value will be null
        /// </summary>        
        ICustomFolder Folder { get; }
        /// <summary>
        /// Script executing on form opening
        /// </summary>
        IScript OnOpenScript { get; set; }
        /// <summary>
        /// Script executing on form closing
        /// </summary>
        IScript OnCloseScript { get; set; }
        /// <summary>
        /// Form type
        /// </summary>
        CoaFormTypes Type { get; }
        /// <summary>
        /// Save changes to form
        /// </summary>
        void Save();
    }
}
