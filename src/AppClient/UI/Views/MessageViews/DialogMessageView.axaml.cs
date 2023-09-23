using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace FlexiObject.AppClient.UI.Views.MessageViews
{
    [DoNotNotify]
    public partial class DialogMessageView : UserControl
    {
        public DialogMessageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
