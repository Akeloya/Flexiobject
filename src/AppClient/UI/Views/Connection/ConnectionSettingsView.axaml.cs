using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.UI.Views.Connection
{
    [DoNotNotify]
    public partial class ConnectionSettingsView : UserControl
    {
        public ConnectionSettingsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
