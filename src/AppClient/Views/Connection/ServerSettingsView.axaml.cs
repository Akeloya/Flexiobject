using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.Views.Connection
{
    [DoNotNotify]
    public partial class ServerSettingsView : UserControl
    {
        public ServerSettingsView()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
