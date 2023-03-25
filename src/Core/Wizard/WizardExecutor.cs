using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Logging;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexiObject.Core.Wizard
{
    public class WizardExecutor : IWizardExecutor
    {
        private readonly IEnumerable<IWizardStep> _steps;
        private readonly ILogger _logger;
        public WizardExecutor(IEnumerable<IWizardStep> steps, LoggerFactory loggerFactory)
        {
            _steps = steps;
            _logger = loggerFactory.Create<WizardExecutor>();
        }

        public void Setup()
        {
            _logger.Trace("Start setup wizard");
            foreach (var step in _steps)
            {
                _logger.Trace($"Start setup step: {step.Name}");
                try
                {
                    if (step.IsBackground)
                    {
                        Task.Run(step.Setup);
                        continue;
                    }
                    step.Setup();
                }
                catch (WizardTerminateExeption)
                {
                    _logger.Warn("$Wizard setup terminated at step {step.Name}");
                    break;
                }
            }
            _logger.Trace("End setup wizard");
        }

        public async Task SetupAsync()
        {
            _logger.Trace("Start setup wizard");
            try
            {
                foreach (var step in _steps)
                {
                    _logger.Trace($"Start setup step: {step.Name}");
                    try
                    {
                        if (step.IsBackground)
                        {
                            _ = Task.Run(step.SetupAsync);
                            continue;
                        }
                        await step.SetupAsync();
                    }
                    catch (WizardTerminateExeption)
                    {
                        _logger.Warn("$Wizard setup terminated at step {step.Name}");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            _logger.Trace("End setup wizard");
        }
    }
}
