using Avalonia.Controls;
using Avalonia.Threading;
using FlexiObject.AppClient.Core.Services.Windows;
using FlexiObject.Core.Config;

using System;

namespace FlexiObject.AppClient.Core
{
    public class ViewModelBase : Screen
    {
        private readonly DispatcherTimer _dispatcherTimer;
        protected IDialogService DialogService { get; }
        public ViewModelBase()
        {
            if(Design.IsDesignMode)
                return;
            DialogService = ServiceLocator.Get<IDialogService>();
            ApiFactory = ServiceLocator.Get<ApiFactory>();
            _dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (_, _) =>
            {
                OnTimerTick();
            });
        }
        protected ApiFactory ApiFactory { get; }
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
