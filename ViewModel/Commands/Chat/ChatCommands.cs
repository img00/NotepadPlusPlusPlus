using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Chat
{
    public class ChatCommands
    {
        public ICommand CmdSwitch { get; } = new CommandSwitch();
    }
}
