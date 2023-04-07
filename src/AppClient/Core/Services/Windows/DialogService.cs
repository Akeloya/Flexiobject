using Avalonia;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;

using FlexiObject.AppClient.Properties;
using FlexiObject.AppClient.Views.MessageView;

using NLog;

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Services.Windows
{
    using Avalonia.Controls;
    /// <inheritdoc/>
    public class DialogService : IDialogService
    {
        private readonly ILogger _logger;
        private readonly IWindowService _windowService;
        public DialogService(LogFactory logFactory, IWindowService windowService)
        {
            _logger = logFactory.GetLogger(nameof(DialogService));
            _windowService = windowService;
        }

        /// <inheritdoc/>
        public Task ShowErrorAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageErrorCaption;
            _logger.Info($"Called ShowError\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("error.png", internalTitle, content: text);
        }

        /// <inheritdoc/>
        public Task ShowErrorAsync(Exception exeption)
        {
            _logger.Info("Called ShowError");
            return CreateDialogWindow("error.png", Resources.DialogMessageErrorCaption, content: exeption);
        }

        /// <inheritdoc/>
        public Task ShowInformationAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageInformationCaption;
            _logger.Info($"Called ShowInformation\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("information.png", internalTitle, content: text);
        }

        /// <inheritdoc/>
        public Task ShowWarningAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageWarningCaption;
            _logger.Info($"Called ShowWarning\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("warning.png", title);
        }

        /// <inheritdoc/>
        public Task<DialogMessageResult> ShowQuestionDialogAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageQuestionCaption;
            _logger.Info($"Called ShowQuestionDialog\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("help-icon.png", title, DialogMessageResult.Ok | DialogMessageResult.Cancel, text);
        }

        /// <inheritdoc/>
        private async Task<DialogMessageResult> CreateDialogWindow(string iconName, string title, DialogMessageResult dialogButtons = DialogMessageResult.None, object content = null)
        {
            _logger.Info("Creating dialog window");
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>()!;
            var bitmap = new Bitmap(assets.Open(new Uri($"avares://FlexiObject.AppClient/Assets/{iconName}")));
            var contentView = new DialogMessageViewModel
            {
                DisplaingContent = content,
                DialogButtons = dialogButtons,
            };
            _logger.Info("Opening dialog window");

            try
            {

                await Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    var wind = await _windowService.CreateDialogAsync(contentView);
                    if (title != null)
                        wind.Title = title;
                    wind.Icon = new WindowIcon(bitmap);
                    await wind.Open(true, _windowService.Current);
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            _logger.Info("Dialog window closed");
            return contentView.DialogMessageResult;
        }

        /// <inheritdoc/>
        public void OpenSetupFolder()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = AppDomain.CurrentDomain.BaseDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        /// <inheritdoc/>
        public Task<string[]> OpenFileDialogAsync(bool allowMultipel = false)
        {
            var ofd = new OpenFileDialog
            {
                AllowMultiple = allowMultipel
            };
            return ofd.ShowAsync(_windowService.Current);
        }

        /// <inheritdoc/>
        public async Task<string> OpenFolderDialogAsync()
        {
            var ofd = new OpenFolderDialog();
            await ofd.ShowAsync(((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow);
            return ofd.Directory;
        }

        /// <inheritdoc/>
        public async Task ShowWindowAsync(object model, DialogProperties props = default)
        {
            var window = await _windowService.CreateDialogAsync(model, props);
            await Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await window.Open();
            });
        }

        /// <inheritdoc/>
        public async Task<bool?> ShowDialogAsync(object model, DialogProperties props = default)
        {
            var window = await _windowService.CreateDialogAsync(model, props);
            var result = await Dispatcher.UIThread.InvokeAsync(async () =>
            {
                var result = await window.Open(true, _windowService.Current);
                return result;
            });
            return result;
        }

        /// <inheritdoc/>
        public DialogPropertyBuilder GetPropesBuilder()
        {
            return new DialogPropertyBuilder();
        }
    }

    public static class DialogServiceExt
    {
        public static async Task<bool?> Open(this Window wnd, bool isDialog = false, Window parent = null)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && isDialog)
            {
                var owner = desktop.MainWindow ?? (parent ?? new Window() { Width = 0, Height = 0, ShowInTaskbar = false });
                if (desktop.MainWindow == null && isDialog && parent == null)
                    owner.Show();

                try
                {
                    var result = await wnd.ShowDialog<bool?>(owner);
                    return result;
                }
                finally
                {
                    if (desktop.MainWindow == null && isDialog && parent == null)
                        owner.Close();
                }
            }
            else
                wnd.Show();
            return default;
        }
    }
}
