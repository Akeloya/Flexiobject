using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using FlexiObject.AppClient.Core;

using NLog;

using PropertyChanged;

using ReactiveUI;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Views
{
    [DoNotNotify]
    public partial class DefaultWindow : ReactiveWindow<Screen>
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public DefaultWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated((disposables) =>
            {
                if (ViewModel == null)
                    return;
                //TODO: Это будет работать только для первой вьюхи, на второй не будет, нужно смотреть смену контекста и переподписывать.
                ViewModel.TryingClose += (s, r) =>
                {
                    Close(r.DialogResult);
                    return Task.CompletedTask;
                };
            });
            Closing += OnClosing;
        }

        private async void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (ViewModel != null)
                    e.Cancel = !await ViewModel.CanCloseAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
