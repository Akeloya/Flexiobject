using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.UI.Views.MessageViews
{
    [DoNotNotify]
    public partial class ErrorMessageView : UserControl
    {
        public ErrorMessageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
