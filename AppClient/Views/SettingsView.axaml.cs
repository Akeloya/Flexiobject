using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace AppClient.Views
{
    [DoNotNotify]
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
