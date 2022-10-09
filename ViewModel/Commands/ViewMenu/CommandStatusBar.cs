using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandStatusBar : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public CommandStatusBar(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainViewModel.MainWindow.StatusBar.Equals(Visibility.Collapsed))
                _mainViewModel.MainWindow.StatusBar = Visibility.Visible;
            else
                _mainViewModel.MainWindow.StatusBar = Visibility.Collapsed;
        }
    }
}
