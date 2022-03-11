using AppClient.Properties;
using AppClient.Views.MessageView;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using NLog;

using System;
using System.Diagnostics;

namespace AppClient.Services
{
    public class DialogService : IDialogService
    {
        private readonly LogFactory _logFactory;
        private readonly ILogger _logger;
        public DialogService(LogFactory logFactory)
        {
            _logger = logFactory.GetLogger(nameof(DialogService));
        }
        public void ShowError(string text, string title = null)
        {
            _logger.Info("Called ShowError");
            CreateDialogWindow("error.png",  title, content:text);
        }

        public void ShowError(Exception exeption)
        {
            _logger.Info("Called ShowError");
            CreateDialogWindow("error.png", Resources.AppTitle, content: exeption);
        }

        public void ShowInformation(string text, string title = null)
        {
            _logger.Info("Called ShowInformation");
            CreateDialogWindow("information.png", title, content: text);
        }

        public void ShowWarning(string text, string title = null)
        {
            _logger.Info("Called ShowWarning");
            CreateDialogWindow("warning.png",  title);
        }
        public DialogMessageResult ShowQuestionDialog(string text, string title = null)
        {
            _logger.Info("Called ShowQuestionDialog");
            return CreateDialogWindow("help-icon.png", title, DialogMessageResult.Ok | DialogMessageResult.Cancel, text);
        }
        private DialogMessageResult CreateDialogWindow(string iconName, string title, DialogMessageResult dialogButtons = DialogMessageResult.None, object content = null)
        {
            _logger.Info("Creating dialog window");
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
            _logger.Info("Opening dialog window");
            wind.Open();
            _logger.Info("Dialog window closed");
            return contentView.DialogMessageResult;
        }

        public void OpenSetupFolder()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = AppDomain.CurrentDomain.BaseDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
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
