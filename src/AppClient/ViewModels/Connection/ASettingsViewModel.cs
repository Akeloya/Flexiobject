using FlexiObject.AppClient.Core.Settings;
using FlexiObject.AppClient.Core.UI;

using ReactiveUI;

using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels.Connection
{
    public abstract class ASettingsViewModel : ReactiveObject, IUpdatableView
    {
        public abstract void Apply();
        public virtual Task ApplyAsync()
        {
            Apply();
            return Task.CompletedTask;
        }
        public abstract void Discard();
    }
}
