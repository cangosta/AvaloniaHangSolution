#nullable enable
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace AvaloniaHangProject.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            tab = this.FindControl<TabItem>("Circle");
            tab.PointerPressed += TabOnPointerPressed;
            tab.PointerMoved += TabOnPointerMoved;
            

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void TabOnPointerMoved(object? sender, PointerEventArgs e) {
            Debug.WriteLine("Moved position" + e.GetPosition(this));
            Debug.WriteLine("Moved current point" + e.GetCurrentPoint(this));
        }

        private void TabOnPointerPressed(object? sender, PointerPressedEventArgs e) {
            Debug.WriteLine("Pressed position" + e.GetPosition(this));
            Debug.WriteLine("Pressed current point" + e.GetCurrentPoint(this));
        }

        private readonly TabItem tab;

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}