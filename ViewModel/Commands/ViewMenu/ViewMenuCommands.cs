using NotepadPlusPlusPlus.ViewModel.Commands.Format;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class ViewMenuCommands
    {
        private readonly MainViewModel _mainViewModel;

        public ViewMenuCommands(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            CmdStatusBar = new CommandStatusBar(mainViewModel);
            CmdZoomIn = new CommandZoomIn(mainViewModel);
            CmdZoomOut = new CommandZoomOut(mainViewModel);
            CmdZoomReset = new CommandZoomReset(mainViewModel);
        }

        public ICommand CmdStatusBar { get; }
        public ICommand CmdZoomIn { get; }
        public ICommand CmdZoomOut { get; }
        public ICommand CmdZoomReset { get; }
    }
}
