using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomReset : CommandBase
    {
        private MainViewModel _mainViewModel;

        public CommandZoomReset(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
                _mainViewModel.MainWindow.ZoomLevel = 1f;
        }
    }
}
