using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.Views
{
    [DoNotNotify]
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
