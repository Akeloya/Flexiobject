using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.Views.Connection
{
    [DoNotNotify]
    public partial class StandaloneSettingsView : UserControl
    {
        public StandaloneSettingsView()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
