using FlexiObject.API;
using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Services;

using System;
using System.Collections.Generic;
using System.Reflection;

namespace FlexiObject.AppClient.ViewModels
{
    public record ComponentInfo(string Name, string Description, string License);
    public class AboutAppViewModel : ViewModelBase
    {
        public AboutAppViewModel(IDialogService dialog, Api api) : base(dialog, api)
        {
            var assembly = typeof(Program).Assembly;
            AppTitle = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            Width = 900;
            Height = 450;
            SizeState = Avalonia.Controls.WindowState.Normal;
        }
        public static AboutAppViewModel Design => new(null, new Api());
        public string OsPlatform => Environment.OSVersion.ToString();
        public string AppTitle { get; }
        public string Version { get; }
        public string Description { get; }
        public ComponentInfo ComponentDescSelected { get; set; }
        public IReadOnlyCollection<ComponentInfo> ComponentItems { get; init; } =
            new[]
            {
                new ComponentInfo("Avalonia", "A cross-platform UI framework for .NET","MIT"),
                new ComponentInfo("Dock", "A docking layout system","MIT"),
                new ComponentInfo("Fody", "Extensible tool for weaving .net assemblies", "MIT"),
                new ComponentInfo("Ninject","The ninja of .net dependency injectors","MIT")
            };
    }
}
