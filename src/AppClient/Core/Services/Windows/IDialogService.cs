using FlexiObject.AppClient.Views.MessageView;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Services.Windows
{
    public interface IDialogService
    {
        /// <summary>
        /// Gets the dialog propes builder.
        /// </summary>
        /// <returns>Builder instance</returns>
        DialogPropertyBuilder GetPropesBuilder();
        /// <summary>
        /// Shows the dialog asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="props">The props.</param>
        /// <returns></returns>
        Task<bool?> ShowDialogAsync(object model, DialogProperties props = default);
        /// <summary>
        /// Shows the window asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="props">The props.</param>
        /// <returns></returns>
        Task ShowWindowAsync(object model, DialogProperties props = default);
        /// <summary>
        /// Shows the error dialog asynchronous.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        Task ShowErrorAsync(string text, string title = null);
        /// <summary>
        /// Shows the error dialog asynchronous.
        /// </summary>
        /// <param name="exeption">The exeption.</param>
        /// <returns></returns>
        Task ShowErrorAsync(Exception exeption);
        /// <summary>
        /// Shows the information dialog asynchronous.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        Task ShowInformationAsync(string text, string title = null);
        /// <summary>
        /// Shows the warning dialog asynchronous.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        Task ShowWarningAsync(string text, string title = null);
        /// <summary>
        /// Shows the question dialog asynchronous.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        Task<DialogMessageResult> ShowQuestionDialogAsync(string text, string title = null);
        /// <summary>
        /// Opens the application setup folder.
        /// </summary>
        void OpenSetupFolder();
        /// <summary>
        /// Opens the file dialog asynchronous.
        /// </summary>
        /// <param name="allowMultiple">if set to <c>true</c> [allow multiple].</param>
        /// <returns></returns>
        Task<string[]> OpenFileDialogAsync(bool allowMultiple);
        /// <summary>
        /// Opens the folder dialog asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<string> OpenFolderDialogAsync();
    }
}
