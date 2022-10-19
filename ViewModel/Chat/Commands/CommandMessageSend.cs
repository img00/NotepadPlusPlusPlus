using NotepadPlusPlusPlus.ViewModel.Main.Commands;
using System.Windows.Threading;
using System;

namespace NotepadPlusPlusPlus.ViewModel.Chat.Commands
{
    public class CommandMessageSend : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string message = MainViewModel.ChatModel.ChatArea.Trim();
            if (message == null || message.Equals(string.Empty)) return;

            //MainViewModel.ChatModel.CaretIndex -= message.Length;
            MainViewModel.ChatModel.CaretIndex = App.MainViewModel.ChatModel.ChatAreaStart;
            MainViewModel.ChatModel.ChatArea = string.Empty;
            MainViewModel.ChatViewModel.ChatState.OnSendMessage(message);

            //MainViewModel.ChatModel.CaretIndex = App.MainViewModel.ChatModel.ChatAreaStart;
            ChatViewModel.MoveCursorChatArea();

        }
    }
}
