using Microsoft.VisualBasic.ApplicationServices;
using NotepadPlusPlusPlus.Model;
using NotepadPlusPlusPlus.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Threading;
using User = NotepadPlusPlusPlus.Model.User;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public class ChatManager
    {
        private static string UsersDatabase = App.DatabaseLocation + "\\users.txt";
        private static string MessagesDatabase = App.DatabaseLocation + "\\chat.txt";
        private FileSystemWatcher _watcher = new FileSystemWatcher(App.DatabaseLocation!);

        public User? User = null;

        private MainViewModel _mainViewModel;
        private ChatViewModel _chatViewModel;

        public ChatManager(MainViewModel mainViewModel, ChatViewModel chatViewModel)
        {
            _mainViewModel = mainViewModel;
            _chatViewModel = chatViewModel;
            AddChatFileWatcher();
        }

        private void AddChatFileWatcher()
        {
            _watcher.NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security;

            _watcher.Changed += UpdateMessagesArea;

            _watcher.Filter = "*.txt";
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        private void UpdateMessagesArea(object sender, FileSystemEventArgs e)
        {
            LoadMessages();
        }

        public void LogOut()
        {
            User = null;
        }

        public bool IsUserRegistered(string username)
        {
            return GetListOfUsernames().Contains(new User(username, string.Empty));
        }

        public bool IsPasswordCorrect(string username, string password)
        {
            return GetUser(username).Password.Equals(password);
        }

        private User GetUser(string username)
        {
            List<User> users = GetListOfUsernames();
            int index = users.IndexOf(new User(username, string.Empty));
            return GetListOfUsernames()[index];
        }

        private List<User> GetListOfUsernames()
        {
            try
            {
                return JsonSerializer.Deserialize<List<User>>(File.ReadAllText(UsersDatabase)) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }

        private List<Message> GetListOfMessages()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Message>>(File.ReadAllText(MessagesDatabase)) ?? new List<Message>();
            }
            catch
            {
                return new List<Message>();
            }
        }

        public void AttemptRetrieveSavedUser()
        {
            _chatViewModel.ChatState = ChatState.WaitingRegisterLogin;
        }

        //TODO: Hash password
        public void Register(string username, string password)
        {
            User = new User(username, password);
            List<User> users = GetListOfUsernames();
            users.Add(User);

            string usersSerialized = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(UsersDatabase, usersSerialized);
        }

        public void Login(string username, string password)
        {
            User = new User(username, password);
        }

        public void SendMessage(string message)
        {
            Message msg = new Message(User!.Username, message);
            List<Message> messages = GetListOfMessages();
            messages.Add(msg);

            string messagesSerialized = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(MessagesDatabase, messagesSerialized);
        }

        public void LoadMessages()
        {
            StringBuilder messages = new();
            
            foreach (Message message in GetListOfMessages())
            {
                messages.Append(message.ToString());
            }
            _mainViewModel.ChatModel.MessagesArea = messages.ToString();

            ChatViewModel.MoveCursorChatArea();
        }
    }
}
