using Avalonia.Controls;

using FlexiObject.AppClient.ViewModels;

using ReactiveUI;

using System;

namespace FlexiObject.AppClient.Views.MessageView
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
        public int Width { get; set; } = 400;
        public int Height { get; set; } = 150;
        public bool CanResize { get; set; } = false;
        public WindowState SizeState { get; set; } = WindowState.Normal;

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
