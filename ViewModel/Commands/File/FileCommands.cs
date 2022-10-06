using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class FileCommands : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        public FileCommands(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            CmdNew = new CommandNew(mainViewModel);
            CmdOpen = new CommandOpen();
            CmdSave = new CommandSave(_mainViewModel);
            CmdSaveAs = new CommandSaveAs(_mainViewModel);
            CmdClose = new CommandClose();
        }


        public ICommand CmdNew { get; set; }
        public ICommand CmdOpen { get; set; }
        public ICommand CmdSave { get; set; }
        public ICommand CmdSaveAs { get; set; }
        public ICommand CmdClose { get; set; }
    }
}
