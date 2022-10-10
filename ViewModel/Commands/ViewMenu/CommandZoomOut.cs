using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomOut : CommandBase
    {
        private MainViewModel _mainViewModel;

        public CommandZoomOut(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainViewModel.MainWindow.ZoomLevel > _mainViewModel.MainWindow.MinZoomLevel)
                _mainViewModel.MainWindow.ZoomLevel -= 0.1f;
        }
    }
}
