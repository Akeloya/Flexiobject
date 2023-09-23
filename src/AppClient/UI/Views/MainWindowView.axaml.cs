using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.UI.Views
{
    [DoNotNotify]
    public partial class MainWindowView : UserControl
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
