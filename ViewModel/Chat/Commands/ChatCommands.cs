using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Chat.Commands
{
    public class ChatCommands
    {
        public ICommand CmdSwitch { get; } = new CommandSwitch();
        public ICommand CmdKeyDown { get; } = new CommandKeyDown();
        public ICommand CmdCutPasteDelete { get; } = new CommandCutPasteDelete();
        public ICommand CmdMessageSend { get; } = new CommandMessageSend();
    }
}
