using AppClient.Properties;
using AppClient.Views.MessageView;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using Ninject;

using System;

namespace AppClient.Services
{
    public class DialogService : IDialogService
    {
        public void ShowError(string text, string title = null)
        {
            CreateDialogWindow("error.png",  title, content:text);
        }

        public void ShowError(Exception exeption)
        {
            CreateDialogWindow("error.png", Resources.AppTitle, content: exeption);
        }

        public void ShowInformation(string text, string title = null)
        {
            CreateDialogWindow("information.png", title, content: text);
        }

        public void ShowWarning(string text, string title = null)
        {
            CreateDialogWindow("warning.png",  title);
        }
        public DialogMessageResult ShowQuestionDialog(string text, string title = null)
        {
            return CreateDialogWindow("help-icon.png", title, DialogMessageResult.Ok | DialogMessageResult.Cancel, text);
        }
        private DialogMessageResult CreateDialogWindow(string iconName, string title, DialogMessageResult dialogButtons = DialogMessageResult.None, object content = null)
        {
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>()!;
            var bitmap = new Bitmap(assets.Open(new Uri($"avares://AppClient/Assets/{iconName}")));
            var contentView = new DialogMessageViewModel
            {
                DisplaingContent = content,
                DialogButtons = dialogButtons,
            };
            var wind = new DialogMessageView {
                Width = 450,
                Height = 150,
                CanResize = false,
                Title = title ?? Resources.AppTitle,                
                Icon = new WindowIcon(bitmap),
                DataContext = contentView
            };
            wind.Open();
            return contentView.DialogMessageResult;
        }
    }

    public static class DialogServiceExt
    {
        public static void Open(this Window wnd)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                wnd.ShowDialog(desktop.MainWindow);
            else
                wnd.Show();
        }
    }
}
