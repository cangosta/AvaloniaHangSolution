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
            StartOpenCloseWindowsCommand = ReactiveCommand.Create(
                () => {
                    Task.Run(() => {
                        // Created this task just to simulate what is happening in the application

                        for (int i = 0; i <= 10; i++) {
                            var exampleWindow = Dispatcher.UIThread.InvokeAsync(() => new DialogWindow() {
                                MinHeight = 500,
                                MinWidth = 500,
                                Position = new PixelPoint(500, 500),
                                Content = new TextBlock() { Text = "Test Content" }
                            }).Result;

                            var exampleWindowTask = Dispatcher.UIThread.InvokeAsync(() => exampleWindow.ShowDialogSync<bool>(parent));

                            Task.Delay(1000).ContinueWith((t) =>
                                Dispatcher.UIThread.InvokeAsync(() => exampleWindow.Close()));

                            exampleWindowTask.Wait();

                            Task.Delay(1000).Wait();
                        }
                    });
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