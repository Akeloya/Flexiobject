﻿using FlexiObject.AppClient.Core.Services.Windows;
using FlexiObject.AppClient.ViewModels;
using FlexiObject.Core.Utilities;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.StartWizard
{
    internal class SetupMainWindowStep : IWindowWizardStep
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly IWindowService _windowService;
        public SetupMainWindowStep(MainWindowViewModel mainWindowViewModel, IWindowService windowService)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _windowService = windowService;
        }
        public ViewModelBase ViewModel => _mainWindowViewModel;

        public string Name => "Setup main window";

        public bool IsBackground => false;

        public event EventHandler<ViewModelBase> OnSetupViewModel;

        public void Setup()
        {
            TaskHelper.RunSync(SetupAsync);
        }

        public async Task SetupAsync()
        {
            await _windowService.SetupMainWindowView(_mainWindowViewModel);
        }
    }
}