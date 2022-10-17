using NotepadPlusPlusPlus.ViewModel.Main;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public class ChatViewModel
    {
        protected readonly MainViewModel _mainViewModel;
        public ChatState ChatState { get; set; }

        public ChatViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void SwitchToChatView()
        {
            App.NotepadView.IsEnabled = false;
            App.ChatView.IsEnabled = true;

            _mainViewModel.CurrentViewModel = App.ChatViewModel;
            _mainViewModel.WindowModel.CurrentView = App.ChatView;
            _mainViewModel.CurrentModel = _mainViewModel.ChatModel;
            _mainViewModel.WindowModel.IsChatting = true;

            if (_mainViewModel.ChatModel.Username == null)
            {

            }
        }

        public static void MoveCursorChatArea()
        {
            App.MainViewModel.CurrentModel.SelectionStart = App.MainViewModel.ChatModel.Text.Length;
            App.MainViewModel.CurrentModel.SelectionLength = 0;
        }

    }

    public enum ChatState
    {
        WaitingRegisterLogin, RegisterWaitingUsername,
        RegisterWaitingPassword, RegisterWaitingPasswordConfirmation,
        LoginWaitingUsername, LoginWaitingPassword, Chatting
    }
}
