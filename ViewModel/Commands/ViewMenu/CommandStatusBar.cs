using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandStatusBar : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindowModel.StatusBar.Equals(Visibility.Collapsed))
                MainViewModel.MainWindowModel.StatusBar = Visibility.Visible;
            else
                MainViewModel.MainWindowModel.StatusBar = Visibility.Collapsed;
        }
    }
}
