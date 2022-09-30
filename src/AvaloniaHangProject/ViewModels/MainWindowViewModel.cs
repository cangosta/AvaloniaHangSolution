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
            OpenSubmitFeedbackWindowCommand = ReactiveCommand.CreateFromTask(
                async () => {
                    var submitFeedbackWindow = new DialogWindow() {
                        MinHeight = 500, MinWidth = 500, Position = new PixelPoint(500, 500),
                    };

                    submitFeedbackWindow.Content = new Button() { Name = "Test Button", Content = "Continue", Command = OnContinueButtonCommand(submitFeedbackWindow, submitFeedbackWindow.Close)};

                    await submitFeedbackWindow.ShowDialog<bool>(parent);

                    
                });


            AddTabCommand = ReactiveCommand.Create(
                () => {
                    ((MainWindow)parent).AddTab(++captionsCounter);
                });
        }

        public ICommand OpenSubmitFeedbackWindowCommand { get; }

        public ICommand AddTabCommand { get; }

        public ICommand OnContinueButtonCommand(Window parent, Action submitFeedbackClose) {

            return ReactiveCommand.CreateFromTask(async () => {

                // Create progress dialog
                var progressWindow = new DialogWindow() {
                    MinHeight = 500, MinWidth = 500, Position = new PixelPoint(500, 500),
                };

                progressWindow.Content = new TextBlock() { Text = "Progress dialog " };

                var dialogResult = progressWindow.ShowDialog<bool>(parent);

                await Task.Delay(1000);

                progressWindow.Close(false);

                await dialogResult;

                submitFeedbackClose();
            });
        }
    }
}