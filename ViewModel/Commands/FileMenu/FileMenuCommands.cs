using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotepadPlusPlusPlus.Model;
using NotepadPlusPlusPlus.ViewModel.Commands.FileMenu;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class FileMenuCommands : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;

        public FileMenuCommands(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            CmdNew = new CommandNew(_mainViewModel);
            CmdOpen = new CommandOpen(_mainViewModel);
            CmdSave = new CommandSave(_mainViewModel);
            CmdSaveAs = new CommandSaveAs(_mainViewModel);
            CmdClose = new CommandClose(_mainViewModel);
            CmdPrint = new CommandPrint(_mainViewModel);
        }


        public ICommand CmdNew { get; set; }
        public ICommand CmdOpen { get; set; }
        public ICommand CmdSave { get; set; }
        public ICommand CmdSaveAs { get; set; }
        public ICommand CmdClose { get; set; }
        public ICommand CmdPrint { get; set; }
    }
}
