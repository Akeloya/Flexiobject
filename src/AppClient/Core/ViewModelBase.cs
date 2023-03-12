using Avalonia.Controls;
using Avalonia.Threading;
using FlexiObject.API;
using FlexiObject.AppClient.Services;

using ReactiveUI;

using System;

namespace FlexiObject.AppClient.Core
{
    public class ViewModelBase : ReactiveObject, IClosableWnd
    {
        private readonly DispatcherTimer _dispatcherTimer;
        protected IDialogService DialogService { get; }
        public ViewModelBase(IDialogService dialog, Api api)
        {
            Api = api;
            DialogService = dialog;
            _dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (_, _) =>
            {
                OnTimerTick();
            });
        }
        protected Api Api { get; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public bool CloseWindow { get; set; }
        public bool CanResize { get; set; } = true;
        public WindowState SizeState { get; set; } = WindowState.Maximized;
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
        public void Close()
        {
            CloseWindow = true;
        }
    }
}
