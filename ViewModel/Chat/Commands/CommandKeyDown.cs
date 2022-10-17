using NotepadPlusPlusPlus.Model.WindowModels;
using NotepadPlusPlusPlus.ViewModel.Commands;
using NotepadPlusPlusPlus.ViewModel.Main;
using System.Linq;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Chat.Commands
{
    public class CommandKeyDown : CommandBase
    {
        private ChatModel _chatModel => MainViewModel.ChatModel;

        public override void Execute(object? parameter)
        {
            if (parameter == null) return;

            KeyEventArgs e = (KeyEventArgs)parameter;
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control) return;
            if (_keysToIgnore.Contains(e.Key)) return;

            if (_chatModel.SelectionStart < _chatModel.ChatAreaStart)
                ChatViewModel.MoveCursorChatArea();

            if (_chatModel.SelectionStart == _chatModel.ChatAreaStart && _chatModel.SelectionLength == 0 && e.Key.Equals(Key.Back))
                e.Handled = true;

            if (e.Key == Key.Enter && Keyboard.Modifiers != ModifierKeys.Shift)
            {
                MainViewModel.ChatCommands.CmdMessageSend.Execute(null);
                e.Handled = true;
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return MainViewModel.WindowModel.IsChatting;
        }

        private Key[] _keysToIgnore = { Key.Up, Key.Down, Key.Left, Key.Right,
            Key.F1, Key.F2, Key.F3, Key.F4, Key.F6, Key.F7, Key.F8, Key.F9, Key.F10, Key.F11, Key.F12,
            Key.CapsLock, Key.LeftShift, Key.RightShift, Key.LWin, Key.RWin, Key.LeftAlt, Key.RightAlt,
            Key.Print, Key.PrintScreen, Key.Scroll, Key.Pause, Key.Insert, Key.Home, Key.End, Key.PageUp, Key.PageDown};
    }
}
