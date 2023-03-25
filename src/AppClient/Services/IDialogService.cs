using FlexiObject.AppClient.Views.MessageView;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Services
{
    public interface IDialogService
    {
        Task<bool?> ShowDialogAsync(object model);
        Task ShowWindowAsync(object model);
        Task ShowErrorAsync(string text, string title = null);
        Task ShowErrorAsync(Exception exeption);
        Task ShowInformationAsync(string text, string title = null);
        Task ShowWarningAsync(string text, string title = null);
        Task<DialogMessageResult> ShowQuestionDialogAsync(string text, string title = null);
        void OpenSetupFolder();
        Task<string[]> OpenFileDialogAsync(bool allowMultiple);
        Task<string> OpenFolderDialogAsync();
    }
} 
