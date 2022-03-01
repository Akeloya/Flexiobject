using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace AppClient.Views.MessageView
{
    [DoNotNotify]
    public partial class DialogMessageView : Window
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
