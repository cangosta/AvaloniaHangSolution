using System.Windows.Input;
using Avalonia.Controls;
using AvaloniaHangProject.Views;
using ReactiveUI;

namespace AvaloniaHangProject.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        private SimpleDialogWindow simpleWindow;

        public MainWindowViewModel(Window parent) {
            OpenSimpleWindowCommand = ReactiveCommand.Create(
                () => {
                    simpleWindow = new SimpleDialogWindow() { MinHeight = 100,  MinWidth = 100,};
                    simpleWindow.Content = new TextBlock() { Text = "Just a window"};
                    simpleWindow.Show(parent);
                }
            );

            CloseSimpleWindowCommand = ReactiveCommand.Create(
                () => {
                    simpleWindow.Close();
                }
            );
        }

        public ICommand OpenSimpleWindowCommand { get; }
        public ICommand CloseSimpleWindowCommand { get; }
    }
}