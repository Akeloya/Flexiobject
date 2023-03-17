using Avalonia;
using Avalonia.ReactiveUI;

using FlexiObject.AppClient.Services;

using Ninject;

using System;
using FlexiObject.Core.Config;

namespace FlexiObject.AppClient
{
    internal class Program
    {
        private static IKernel _kernel;
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            _kernel = new StandardKernel();
            var diBindings = new AppBindings();
            _kernel.Load(diBindings);

            BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

            DisposeThis();
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure(()=> new App(_kernel?.Get<IContainer>()))
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
        public static void DisposeThis()
        {
            _kernel?.Dispose();
        }
    }
}
