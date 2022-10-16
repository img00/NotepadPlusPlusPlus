using NotepadPlusPlusPlus.ViewModel.Commands;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class ChatViewModel
    {
        private readonly MainViewModel _mainViewModel = App.MainViewModel;
        public ICommand CmdKeyDownChat { get; }
        public ICommand CmdEditingCommandTriggered { get; }

        public ChatViewModel()
        {
            CmdKeyDownChat = new KeyDownChatCommand(this);
            CmdEditingCommandTriggered = new EditingCommandTriggered(this);
        }

        public void SwitchToChatView()
        {
            App.NotepadView.IsEnabled = false;
            App.ChatView.IsEnabled = true;

            _mainViewModel.CurrentViewModel = App.ChatViewModel;
            _mainViewModel.MainWindowModel.CurrentView = App.ChatView;
            _mainViewModel.CurrentWindowModel = _mainViewModel.ChatWindowModel;
            _mainViewModel.MainWindowModel.IsChatting = true;
        }

        public static void MoveToCorrectSpot()
        {
            App.MainViewModel.CurrentWindowModel.SelectionStart = App.MainViewModel.ChatWindowModel.Text.Length;
            App.MainViewModel.CurrentWindowModel.SelectionLength = 0;
        }

    }


    public class KeyDownChatCommand : CommandBase
    {
        private ChatViewModel _chatViewModel;

        public KeyDownChatCommand(ChatViewModel chatViewModel)
        {
            _chatViewModel = chatViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter == null) return;

            KeyEventArgs e = (KeyEventArgs)parameter;
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control) return;
            if (_keysToIgnore.Contains(e.Key)) return;

            if (App.MainViewModel.ChatWindowModel.SelectionStart < App.MainViewModel.ChatWindowModel.ChatAreaStart)
                ChatViewModel.MoveToCorrectSpot();

            if (App.MainViewModel.ChatWindowModel.SelectionStart == App.MainViewModel.ChatWindowModel.ChatAreaStart && App.MainViewModel.ChatWindowModel.SelectionLength == 0 && e.Key.Equals(Key.Back))
                e.Handled = true;
        }

        public override bool CanExecute(object? parameter)
        {
            return MainViewModel.MainWindowModel.IsChatting;
        }

        private Key[] _keysToIgnore = { Key.Up, Key.Down, Key.Left, Key.Right,
            Key.F1, Key.F2, Key.F3, Key.F4, Key.F6, Key.F7, Key.F8, Key.F9, Key.F10, Key.F11, Key.F12,
            Key.CapsLock, Key.LeftShift, Key.RightShift, Key.LWin, Key.RWin, Key.LeftAlt, Key.RightAlt,
            Key.Print, Key.PrintScreen, Key.Scroll, Key.Pause, Key.Insert, Key.Home, Key.End, Key.PageUp, Key.PageDown};
    }

    public class EditingCommandTriggered : CommandBase
    {
        private ChatViewModel _chatViewModel;

        public EditingCommandTriggered(ChatViewModel chatViewModel)
        {
            _chatViewModel = chatViewModel;
        }

        //TODO: Need to fix that. Should get the correct range where you can write
        public override void Execute(object? parameter)
        {
            if (parameter == null) return;

            ExecutedRoutedEventArgs e = (ExecutedRoutedEventArgs)parameter;

            if (App.MainViewModel.ChatWindowModel.SelectionStart < App.MainViewModel.ChatWindowModel.ChatAreaStart)
            {
                if (e.Command.Equals(ApplicationCommands.Cut))
                {
                    ApplicationCommands.Copy.Execute(null, null);
                    e.Handled = true;
                    return;
                }

                ChatViewModel.MoveToCorrectSpot();
            }

            if (e.Command.Equals(ApplicationCommands.Cut))
            {
                Clipboard.SetText(App.MainViewModel.ChatWindowModel.SelectedText);
                App.MainViewModel.ChatWindowModel.SelectedText = string.Empty;
            }
            else if (e.Command.Equals(ApplicationCommands.Paste))
            {
                App.MainViewModel.ChatWindowModel.SelectedText = Clipboard.GetText();
                App.MainViewModel.ChatWindowModel.SelectionStart += App.MainViewModel.ChatWindowModel.SelectionLength;
                App.MainViewModel.ChatWindowModel.SelectionLength = 0;
            }
            else if (e.Command.Equals(EditingCommands.Delete))
            {
                if (App.MainViewModel.ChatWindowModel.SelectionLength > 0)
                {
                    App.MainViewModel.ChatWindowModel.SelectedText = string.Empty;
                }
                else
                {
                    App.MainViewModel.ChatWindowModel.SelectionLength += 1;
                    App.MainViewModel.ChatWindowModel.SelectedText = string.Empty;
                    App.MainViewModel.ChatWindowModel.SelectionLength = 0;
                }
                    
            }
            

            
            e.Handled = true;
        }

        public override bool CanExecute(object? parameter)
        {
            return MainViewModel.MainWindowModel.IsChatting;
        }
    }
}
