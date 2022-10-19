using NotepadPlusPlusPlus.ViewModel.Main;
using System;
using System.Threading;
using System.Windows.Threading;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public class ChatViewModel
    {
        private readonly MainViewModel _mainViewModel;
        public ChatManager ChatManager { get; set; }
        public ChatMessageSentActions ChatMessageSentActions { get; set; }

        public event EventHandler ChatStateChanged;
        private ChatState _chatState;
        public ChatState ChatState
        {
            get => _chatState;
            set
            {
                _chatState = value;
                ChatStateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public ChatViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ChatMessageSentActions = new ChatMessageSentActions(_mainViewModel);
            ChatStateChanged += OnChatStateChanged;
            ChatManager = new ChatManager(_mainViewModel, this);
            ChatManager.AttemptRetrieveSavedUser();
            ChatManager.LoadMessages();
        }

        private void OnChatStateChanged(object? sender, EventArgs e)
        {
            _mainViewModel.ChatModel.NotificationsArea = ChatState.NotificationMessage;
        }

        public void SwitchToChatView()
        {
            App.NotepadView!.IsEnabled = false;
            App.ChatView!.IsEnabled = true;

            _mainViewModel.CurrentViewModel = App.ChatViewModel!;
            _mainViewModel.WindowModel.CurrentView = App.ChatView;
            _mainViewModel.CurrentModel = _mainViewModel.ChatModel;
            _mainViewModel.WindowModel.IsChatting = true;
        }

        public static void MoveCursorChatArea()
        {

            //App.MainViewModel.ChatModel.SelectionStart = App.MainViewModel.ChatModel.Text.Length;
            App.MainViewModel.ChatModel.SelectionLength = 0;
            App.MainViewModel.ChatModel.CaretIndex = App.MainViewModel.ChatModel.Text.Length;
        }

    }
}
