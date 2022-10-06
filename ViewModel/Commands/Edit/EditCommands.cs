using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    public class EditCommands : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        public EditCommands(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            CmdDate = new CommandDate();
            CmdSearchBing = new CommandSearchBing();
        }

        public ICommand CmdDate { get; set; }
        public ICommand CmdSearchBing { get; set; }

    }
}
