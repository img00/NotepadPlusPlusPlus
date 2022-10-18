using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.EditMenu
{
    public class EditMenuCommands
    {
        public ICommand CmdDate { get; } = new CommandDate();
        public ICommand CmdSearchBing { get; } = new CommandSearchBing();
    }
}
