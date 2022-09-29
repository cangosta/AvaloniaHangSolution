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
            OpenSubmitFeedbackWindowCommand = ReactiveCommand.Create(
                () => {
                    Task.Run(() => { // Created this task just to simulate what is happening in the application

                        var submitFeedbackWindow = Dispatcher.UIThread.InvokeAsync(() => {
                            var sfWindow = new DialogWindow() {
                                MinHeight = 500, MinWidth = 500, Position = new PixelPoint(500, 500),
                            };

                            sfWindow.Content = new Button() { Name = "Test Button", Content = "Continue", Command = OnContinueButtonCommand(parent, sfWindow.Close)};

                            return sfWindow;
                        }).Result;


                        var res = Dispatcher.UIThread.InvokeAsync(() => submitFeedbackWindow.ShowDialogSync<bool>(parent)).Result;

                        // create fake modal dialog
                        //var keepWorkingWindow

                    });
                }
            );


            AddTabCommand = ReactiveCommand.Create(
                () => {
                    ((MainWindow)parent).AddTab(++captionsCounter);
                });
        }

        public ICommand OpenSubmitFeedbackWindowCommand { get; }

        public ICommand AddTabCommand { get; }

        public ICommand OnContinueButtonCommand(Window parent, Action submitFeedbackClose) {
            // TODO check who is the parent window in the SS scenario? the submitFeedbackWindow or the AppWindow? Right now I'm using the app window
            return ReactiveCommand.Create(() => {
                Task.Run(() => {
                    // Create progress dialog
                    var progressWindow = Dispatcher.UIThread.InvokeAsync(() => {
                        var pWindow = new DialogWindow() {
                            MinHeight = 500,
                            MinWidth = 500,
                            Position = new PixelPoint(500, 500),
                        };

                        pWindow.Content = new TextBlock() { Text = "Progress dialog "};

                        return pWindow;
                    }).Result;

                    // set timer to close progress dialog

                    var showProgressWindowTask = Dispatcher.UIThread.InvokeAsync(() => progressWindow.ShowDialogSync<bool>(parent));

                    Task.Delay(1000).ContinueWith((t) => Dispatcher.UIThread.InvokeAsync(() => progressWindow.Close()));

                    var res = showProgressWindowTask.Result;

                    // close the submit feedback window
                    Dispatcher.UIThread.InvokeAsync(() => submitFeedbackClose.Invoke());
                });

            });
        }
    }
}