using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotepadPlusPlusPlus.Model;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Format
{
    public class FormatMenuCommands
    {
        private readonly MainViewModel _mainViewModel;

        public FormatMenuCommands(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            CmdWrap = new CommandWrap(mainViewModel);
        }

        public ICommand CmdWrap { get; set; }

    }
}
