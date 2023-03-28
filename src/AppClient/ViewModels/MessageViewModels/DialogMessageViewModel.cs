using Avalonia.Controls;

using FlexiObject.AppClient.Core;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Views.MessageView
{
    [Flags]
    public enum DialogMessageResult
    {
        None,
        Ok,
        Cancel
    }
    public class DialogMessageViewModel : Screen
    {
        public object DisplaingContent { get; set; }
        public DialogMessageResult DialogMessageResult { get; set; }
        public DialogMessageResult DialogButtons { get; set; }
        public bool ShowOkButton => (DialogButtons & DialogMessageResult.Ok) == DialogMessageResult.Ok;
        public bool ShowCancelButton => (DialogButtons & DialogMessageResult.Cancel) == DialogMessageResult.Cancel;
        public WindowState SizeState { get; set; } = WindowState.Normal;
        public Task Submit()
        {
            DialogMessageResult = DialogMessageResult.Ok;
            return TryCloseAsync(true);
        }

        public Task Cancel()
        {
            DialogMessageResult = DialogMessageResult.Cancel;
            return TryCloseAsync(false);
        }

        public Task Close()
        {
            return TryCloseAsync();
        }
    }
}
