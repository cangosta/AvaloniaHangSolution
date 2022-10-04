using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using AvaloniaHangProject.Views;
using ReactiveUI;

namespace AvaloniaHangProject.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        private int captionsCounter = 0;

        public MainWindowViewModel(Window parent) {
            StartOpenCloseWindowsCommand = ReactiveCommand.CreateFromTask(
                async () => {

                    // Created this task just to simulate what is happening in the application
                    for (int i = 0; i <= 10; i++) {
                        var exampleWindow = new DialogWindow() {
                            MinHeight = 500,
                            MinWidth = 500,
                            Position = new PixelPoint(500, 500),
                            Content = new TextBlock() { Text = "Test Content" }
                        };

                        var exampleWindowTask = exampleWindow.ShowDialogSync<bool>(parent);

                        await Task.Delay(1000);

                        exampleWindow.Close();

                        await exampleWindowTask;

                        await Task.Delay(1000);
                    }
                }
            );


            AddTabCommand = ReactiveCommand.Create(
                () => {
                    ((MainWindow)parent).AddTab(++captionsCounter);
                });
        }

        public ICommand StartOpenCloseWindowsCommand { get; }

        public ICommand AddTabCommand { get; }
    }
}