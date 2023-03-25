using Avalonia.Controls;
using Avalonia.Threading;

using FlexiObject.AppClient.Services;
using FlexiObject.Core.Config;

using ReactiveUI;

using System;

namespace FlexiObject.AppClient.Core
{
    public class ViewModelBase : Screen
    {
        private readonly DispatcherTimer _dispatcherTimer;
        protected IDialogService DialogService { get; }
        public ViewModelBase()
        {
            DialogService = ServiceLocator.Get<IDialogService>();
            ApiFactory = ServiceLocator.Get<ApiFactory>();
            _dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (_, _) =>
            {
                OnTimerTick();
            });
        }
        protected ApiFactory ApiFactory { get; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public bool CloseWindow { get; set; }
        public bool CanResize { get; set; } = true;
        public WindowState SizeState { get; set; } = WindowState.Maximized;

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        protected virtual void OnTimerTick()
        {

        }

        protected void StartTimer()
        {
            _dispatcherTimer.Start();
        }

        protected void StopTimer()
        {
            _dispatcherTimer.Stop();
        }
    }
}
