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
        public bool CloseWindow { get; set; }
        public DialogMessageResult DialogMessageResult { get; set; }
        public DialogMessageResult DialogButtons { get; set; }
        public bool ShowOkButton => (DialogButtons & DialogMessageResult.Ok) == DialogMessageResult.Ok;
        public bool ShowCancelButton => (DialogButtons & DialogMessageResult.Cancel) == DialogMessageResult.Cancel;
        public int Width { get; set; } = 400;
        public int Height { get; set; } = 150;
        public bool CanResize { get; set; } = false;
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
    }
}
