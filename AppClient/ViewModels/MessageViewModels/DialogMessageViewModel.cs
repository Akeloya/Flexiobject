using AppClient.ViewModels;

using ReactiveUI;

using System;

namespace AppClient.Views.MessageView
{
    [Flags]
    public enum DialogMessageResult
    {
        None,
        Ok,
        Cancel
    }
    public class DialogMessageViewModel : ReactiveObject, IClosableWnd
    {
        public object DisplaingContent { get; set; }
        public bool CloseWindow { get; set; }
        public DialogMessageResult DialogMessageResult { get; set; }
        public DialogMessageResult DialogButtons { get; set; }
        public bool ShowOkButton => (DialogButtons & DialogMessageResult.Ok) == DialogMessageResult.Ok;
        public bool ShowCancelButton => (DialogButtons & DialogMessageResult.Cancel) == DialogMessageResult.Cancel;
        public void Close()
        {
            CloseWindow = true;
        }

        public void Submit()
        {
            DialogMessageResult = DialogMessageResult.Ok;
            Close();
        }

        public void Cancel()
        {
            DialogMessageResult = DialogMessageResult.Cancel;
            Close();
        }
    }
}
