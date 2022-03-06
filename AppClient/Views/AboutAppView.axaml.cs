using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace AppClient.Views
{
    [DoNotNotify]
    public partial class AboutAppView : UserControl
    {
        public AboutAppView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
