using FlexiObject.AppClient.Properties;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using NLog;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FlexiObject.AppClient.Views.MessageView;
using Avalonia.Threading;
using FlexiObject.Core.Utilities;
using System.Threading;

namespace FlexiObject.AppClient.Services
{
    public class DialogService : IDialogService
    {
        private readonly ILogger _logger;
        private readonly IWindowService _windowService;
        public DialogService(LogFactory logFactory, IWindowService windowService)
        {
            _logger = logFactory.GetLogger(nameof(DialogService));
            _windowService = windowService;
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
            var bitmap = new Bitmap(assets.Open(new Uri($"avares://FlexiObject.AppClient/Assets/{iconName}")));
            var contentView = new DialogMessageViewModel
            {
                DisplaingContent = content,
                DialogButtons = dialogButtons,
            };
            var wind = _windowService.CreateDialog(contentView);
            
            _logger.Info("Opening dialog window");
            
            TaskHelper.RunSync(() => Dispatcher.UIThread.InvokeAsync(() =>
            {
                if(title != null)
                wind.Title = title;
                wind.Icon = new WindowIcon(bitmap);
                wind.Open();
            }));
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

        public Task<string[]> OpenFileDialogAsync(bool allowMultipel = false)
        {
            var ofd = new OpenFileDialog
            {
                AllowMultiple = allowMultipel
            };
            return ofd.ShowAsync(_windowService.Current);
        }

        public Task<string> OpenFolderDialogAsync()
        {
            throw new NotImplementedException();
        }
    }

    public static class DialogServiceExt
    {
        public static void Open(this Window wnd)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow != null)
                wnd.ShowDialog(desktop.MainWindow);
            else
                wnd.Show();
        }
    }
}
