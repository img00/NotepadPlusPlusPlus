using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandStatusBar : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.WindowModel.StatusBar.Equals(Visibility.Collapsed))
                MainViewModel.WindowModel.StatusBar = Visibility.Visible;
            else
                MainViewModel.WindowModel.StatusBar = Visibility.Collapsed;
        }
    }
}
