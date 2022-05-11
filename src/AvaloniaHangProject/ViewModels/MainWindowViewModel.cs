using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives.PopupPositioning;
using ReactiveUI;

namespace AvaloniaHangProject.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        public MainWindowViewModel(Window parent) {
            ButtonClickExampleCommand = ReactiveCommand.Create(
                () => {
                     var menu = new ContextMenu();
                    
                     menu.Items = new MenuItem[] {
                         new MenuItem() { Header = "Option 1", Command = Option1Command },
                         new MenuItem() { Header = "Option 2", Command = Option2Command },
                     };
                    
                     menu.PlacementAnchor = PopupAnchor.TopLeft;
                     menu.PlacementGravity = PopupGravity.BottomRight;
                     menu.PlacementMode = PlacementMode.AnchorAndGravity;
                     menu.PlacementRect = new Rect(100, 100, 1, 1);
            
                    menu.Open(parent);
                }
            );

            CloseGuidedTourExampleCommand = ReactiveCommand.Create(
                () => {
                }
            );
            
            Option1Command = ReactiveCommand.Create(Option1);
            Option2Command = ReactiveCommand.Create(Option2);
        }

        public ICommand ButtonClickExampleCommand { get; }
        public ICommand CloseGuidedTourExampleCommand { get; }
        
        private ICommand Option1Command { get; }
        private ICommand Option2Command { get; }
        
        private static void Option1()
        {
            System.Diagnostics.Debug.WriteLine("Option1 clicked");
        }
        
        private static void Option2()
        {
            System.Diagnostics.Debug.WriteLine("Option2 clicked");
        }
    }
}