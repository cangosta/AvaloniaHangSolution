using System;
using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;

namespace AvaloniaHangProject.Views {
    public class DialogWindow : MainWindow {

        public bool IsModal { get; private set; }

        public DialogWindow() {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
        }

        public DialogWindow(Window aggregatorWindow) : this() {
            ParentWindow = aggregatorWindow;
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public Window ParentWindow { get; }

        private void SafeShow(Window ownerWindow = null) {
            SafeShowCore(ownerWindow);
        }

        private static bool IsWindowValid(Window window) => window?.IsVisible == true && !(window is DialogWindow dialog);


        private void SafeShowCore(Window ownerWindow = null) {
            if (IsWindowValid(ownerWindow)) {
                ShowInTaskbar = false;
                Show(ownerWindow);
            } else {
                Show();
            }
        }


        public void DisplayModal(bool applicationWideModal) {
            ShowWindow(true);
        }

        private void ShowWindow(bool showAsModal) {
            IsModal = showAsModal;

            SafeShow();
        }

    }
}