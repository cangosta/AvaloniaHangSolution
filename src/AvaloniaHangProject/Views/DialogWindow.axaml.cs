using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;

namespace AvaloniaHangProject.Views {
    public class DialogWindow : MainWindow {

        public DialogWindow() {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}