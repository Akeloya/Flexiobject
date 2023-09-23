using FlexiObject.AppClient.Core.Window;

using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core
{
    /// <summary>
    /// TODO: replace all this??...
    /// </summary>
    public static class AsyncEventHandlerExtensions
    {
        public static IEnumerable<AsyncEventHandler<TEventArgs>> GetHandlers<TEventArgs>(
            this AsyncEventHandler<TEventArgs> handler) where TEventArgs : EventArgs
            => handler.GetInvocationList().Cast<AsyncEventHandler<TEventArgs>>();

        public static Task InvokeAllAsync<TEventArgs>(
            this AsyncEventHandler<TEventArgs> handler, object sender, TEventArgs e) where TEventArgs : EventArgs
            => Task.WhenAll(handler.GetHandlers().Select(handleAsync => handleAsync(sender, e)));
    }
    public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;
    public class DeactivationEventArgs : EventArgs
    {
        public bool WasClosed { get; set; }
    }
    public class ActivationEventArgs : EventArgs
    {
        public bool WasInitialized { get; set; }
    }

    public class ClosingEventArgs : EventArgs
    {
        public bool? DialogResult { get; set; }
    }
    public class Screen : ReactiveObject, IActivatableViewModel, Window.IScreen
    {
        public Screen()
        {
            DisplayName = GetType().Name;
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                ((IActivate)this).ActivateAsync();
                Disposable
                    .Create(async () => { await ((IDeactivate)this).DeactivateAsync(true, default); })
                    .DisposeWith(disposables);
            });
        }
        public virtual string DisplayName { get; set; }

        public bool IsActive { get; private set; }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        async Task IActivate.ActivateAsync(CancellationToken cancellationToken)
        {
            if (IsActive)
                return;

            var initialized = false;

            await OnActivateAsync(cancellationToken);
            IsActive = true;

            await (Activated?.InvokeAllAsync(this, new ActivationEventArgs
            {
                WasInitialized = initialized
            }) ?? Task.FromResult(true));
        }

        public virtual Task<bool> CanCloseAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        async Task IDeactivate.DeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            if (IsActive || close)
            {
                await OnDeactivateAsync(close, cancellationToken);
                IsActive = false;

                await (Deactivated?.InvokeAllAsync(this, new DeactivationEventArgs
                {
                    WasClosed = close
                }) ?? Task.FromResult(true));
            }
        }

        public virtual async Task TryCloseAsync(bool? dialogResult = null)
        {
            await TryingClose?.InvokeAllAsync(this, new ClosingEventArgs
            {
                DialogResult = dialogResult
            });
        }

        public event AsyncEventHandler<ActivationEventArgs> Activated = delegate { return Task.FromResult(true); };

        public event AsyncEventHandler<DeactivationEventArgs> Deactivated = delegate { return Task.FromResult(true); };

        public event AsyncEventHandler<ClosingEventArgs> TryingClose = delegate { return Task.FromResult(true); };
        protected virtual Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        protected virtual Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        protected virtual Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
