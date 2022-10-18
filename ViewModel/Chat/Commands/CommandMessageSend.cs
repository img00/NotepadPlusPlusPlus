using NotepadPlusPlusPlus.ViewModel.Main.Commands;

namespace NotepadPlusPlusPlus.ViewModel.Chat.Commands
{
    public class CommandMessageSend : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string message = MainViewModel.ChatModel.ChatArea.Trim();
            if (message == null || message.Equals(string.Empty)) return;

            MainViewModel.ChatViewModel.ChatState.SendMessage(message);

            MainViewModel.ChatModel.ChatArea = string.Empty;
            ChatViewModel.MoveCursorChatArea();
        }
    }
}
