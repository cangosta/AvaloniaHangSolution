using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaHangProject.ViewModels;

namespace AvaloniaHangProject.Views {
    public class MainWindow : Window {
        private readonly TabControl tabs;
        public MainWindow() {
            InitializeComponent();

            tabs = this.FindControl<TabControl>("tabs");


#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public void AddTab(int index) {
            var header = new TabHeaderInfo();
            header.Caption = "Caption " + index;

            var view = new Button() {
                Name = "view",
                Content = "Open SubmitFeedback Window Example",
                Command = ((MainWindowViewModel)this.DataContext).OpenSubmitFeedbackWindowCommand
            };

            var tab = new TabItem() {
                Content = view,
                DataContext = header,
                Header = header,
                IsVisible = true
            };

            ((IList)tabs.Items).Add(tab);
        }
    }
}