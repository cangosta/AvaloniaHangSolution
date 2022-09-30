using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;

namespace AvaloniaHangProject.Views {
    public class SimpleDialogWindow : Window {

        public SimpleDialogWindow() {
            InitializeComponent();
            SetupWindowDimensions();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void SetupWindowDimensions() {
            SizeToContent = SizeToContent.WidthAndHeight;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
        }
    }
}