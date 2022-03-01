using AppClient.Views.MessageView;

using System;

namespace AppClient.Services
{
    public interface IDialogService
    {
        void ShowError(string text, string title = null);
        void ShowError(Exception exeption);
        void ShowInformation(string text, string title = null);
        void ShowWarning(string text, string title = null);
        DialogMessageResult ShowQuestionDialog(string text, string title = null);
    }
}
