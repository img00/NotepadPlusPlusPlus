using NotepadPlusPlusPlus.ViewModel.Commands;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class ChatViewModel
    {
        private MainViewModel _mainViewModel;
        public ICommand CmdKeyDownChat { get; } = new KeyDownChatCommand();

        public ChatViewModel (MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void SwitchChat(bool chatOn)
        {
            _mainViewModel.MainWindow.IsChatting = chatOn;
            _mainViewModel.DocumentChanged();
        }

    }


    public class KeyDownChatCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter == null) return;

            KeyEventArgs e = (KeyEventArgs)parameter;

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.V)
            {
                e.Handled = true;
            }

        }

        public override bool CanExecute(object? parameter)
        {
            return MainViewModel.MainWindow.IsChatting;
        }
    }
}
