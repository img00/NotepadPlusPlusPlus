using System;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Chat
{
    public class CommandSwitch : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MainViewModel.ChatViewModel.SwitchChat(!MainViewModel.MainWindow.IsChatting);
        }
    }
}
