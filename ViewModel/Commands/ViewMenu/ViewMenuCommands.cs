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
        }

        public ICommand CmdStatusBar { get; set; }
    }
}
