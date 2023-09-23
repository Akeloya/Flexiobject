using Avalonia;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;

using FlexiObject.AppClient.Properties;

using NLog;

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Services.Windows
{
    using Avalonia.Controls;
    using FlexiObject.AppClient.UI.ViewModels.MessageViewModels;

    /// <inheritdoc/>
    public class DialogService : IDialogService
    {
        private readonly ILogger _logger;
        private readonly IWindowService _windowService;
        private readonly ViewLocator _viewLocator;
        private const int DefaultMaxWidth = 600;
        private readonly DialogPropertyBuilder _defaultProps;
        public DialogService(LogFactory logFactory, IWindowService windowService, ViewLocator viewLocator)
        {
            _logger = logFactory.GetLogger(nameof(DialogService));
            _windowService = windowService;
            _viewLocator = viewLocator;
            _defaultProps = new DialogPropertyBuilder().MaxWidth(DefaultMaxWidth);
        }

        /// <inheritdoc/>
        public Task ShowErrorAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageErrorCaption;
            _logger.Info($"Called ShowError\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("error.png", internalTitle, new ErrorMessageViewModel(text), props: _defaultProps.MaxHeight(500).Build());
        }

        /// <inheritdoc/>
        public Task ShowErrorAsync(Exception exeption, string message = null, string title = null)
        {
            _logger.Info("Called ShowError");
            return CreateDialogWindow("error.png", title ?? Resources.DialogMessageErrorCaption, new ErrorMessageViewModel(message, exeption), props: _defaultProps.MaxHeight(500).Build());
        }

        /// <inheritdoc/>
        public Task ShowInformationAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageInformationCaption;
            _logger.Info($"Called ShowInformation\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("information.png", internalTitle, text, props: _defaultProps.Build());
        }

        /// <inheritdoc/>
        public Task ShowWarningAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageWarningCaption;
            _logger.Info($"Called ShowWarning\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("warning.png", title, text, props: _defaultProps.Build());
        }

        /// <inheritdoc/>
        public Task<DialogMessageResult> ShowQuestionDialogAsync(string text, string title = null)
        {
            var internalTitle = title ?? Resources.DialogMessageQuestionCaption;
            _logger.Info($"Called ShowQuestionDialog\nText: {text}\nTitle: {internalTitle}");
            return CreateDialogWindow("help-icon.png", title, text, DialogMessageResult.Ok | DialogMessageResult.Cancel, _defaultProps.Build());
        }


        /// <inheritdoc/>
        private async Task<DialogMessageResult> CreateDialogWindow(string iconName, string title, object content, DialogMessageResult dialogButtons = DialogMessageResult.None, DialogProperties props = default)
        {
            _logger.Info("Creating dialog window");
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>()!;
            var bitmap = new Bitmap(assets.Open(new Uri($"avares://FlexiObject.AppClient/Assets/{iconName}")));
            var contentView = new DialogMessageViewModel
            {
                DialogButtons = dialogButtons,
            };

            if(content.GetType().Name.EndsWith("ViewModel"))
            {
                try
                {
                    await Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        var view = _viewLocator.Build(content);
                        view.DataContext = content;
                        contentView.DisplaingContent = view;
                    });
                    
                }
                catch(Exception ex)
                {
                    contentView.DisplaingContent = ex.Message;
                }
                
            }
            else
                contentView.DisplaingContent = content;
            _logger.Info("Opening dialog window");

            try
            {

                await Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    var wind = await _windowService.CreateDialogAsync(contentView, props);
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
