using NotepadPlusPlusPlus.ViewModel.Commands;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand CmdNew { get; } = new CommandNew();
        public ICommand CmdOpen { get; } = new CommandOpen();
        public ICommand CmdSave { get; } = new CommandSave();
        public ICommand CmdSaveAs { get; } = new CommandSaveAs();
        public ICommand CmdClose { get; } = new CommandClose();

        public ICommand CmdZoom { get; } = new CommandZoom();

    }

}
