using NotepadPlusPlusPlus.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public class ChatMessageSentActions
    {
        private readonly MainViewModel _mainViewModel;
        private readonly string _usernameRegex = @"^(?=.{3,14}$)([a-zA-Z0-9][_-]*)*$";

        public ChatMessageSentActions(MainViewModel mainViewModel) => _mainViewModel = mainViewModel;

        public void ChooseRegisterLogin(string message)
        {
            char choice = message[0];

            switch (choice)
            {
                case '1':
                    _mainViewModel.ChatViewModel.ChatState = ChatState.RegisterWaitingUsername;
                    return;
                case '2':
                    _mainViewModel.ChatViewModel.ChatState = ChatState.LoginWaitingUsername;
                    return;
            }
        }

        public void ChooseUsernameRegister(string message)
        {
            if (!Regex.IsMatch(message, _usernameRegex))
            {
                _mainViewModel.ChatModel.NotificationsArea = "El usuario debe contener entre 3 y 14 caracteres (letras, números, guiones o barras bajas).";
                return;
            }
        }
    }
}
