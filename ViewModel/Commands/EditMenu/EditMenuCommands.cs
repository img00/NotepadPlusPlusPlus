using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    public class EditMenuCommands
    {
        public ICommand CmdDate { get; } = new CommandDate();
        public ICommand CmdSearchBing { get; } = new CommandSearchBing();
    }
}
