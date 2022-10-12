using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandStatusBar : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindow.StatusBar.Equals(Visibility.Collapsed))
                MainViewModel.MainWindow.StatusBar = Visibility.Visible;
            else
                MainViewModel.MainWindow.StatusBar = Visibility.Collapsed;
        }
    }
}
