using NotepadPlusPlusPlus.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public class ChatMessageSentActions
    {
        private readonly MainViewModel _mainViewModel;
        private readonly string _usernameRegex = @"^(?=.{3,14}$)([a-zA-Z0-9][_-]*)*$";
        private readonly string _passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d \[\]!@#$@^&*_-]{8,}$";

        private string _tempUsername = string.Empty;
        private string _tempPassword = string.Empty;

        public ChatMessageSentActions(MainViewModel mainViewModel) => _mainViewModel = mainViewModel;

        public void ChooseRegisterLogin(string message)
        {
            char choice = message[0];

            switch (choice)
            {
                case '1':
                    _mainViewModel.ChatViewModel.ChatState = ChatState.LoginWaitingUsername;
                    return;
                case '2':
                    _mainViewModel.ChatViewModel.ChatState = ChatState.RegisterWaitingUsername;
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

            if (_mainViewModel.ChatViewModel.ChatManager.IsUserRegistered(message))
            {
                _mainViewModel.ChatModel.NotificationsArea = "El usuario ya está registrado.";
                return;
            }

            _mainViewModel.ChatViewModel.ChatState = ChatState.RegisterWaitingPassword;
            _tempUsername = message;
        }

        public void ChoosePasswordRegister(string message)
        {
            if (!Regex.IsMatch(message, _passwordRegex))
            {
                _mainViewModel.ChatModel.NotificationsArea = "La contraseña debe contener al menos 8 caracteres (mínimo una letra y un número).";
                return;
            }

            _mainViewModel.ChatViewModel.ChatState = ChatState.RegisterWaitingPasswordConfirmation;
            _tempPassword = message;
        }

        public void ChoosePasswordConfirmationRegister(string message)
        {
            if (!_tempPassword.Equals(message))
            {
                _mainViewModel.ChatViewModel.ChatState = ChatState.RegisterWaitingPassword;
                _mainViewModel.ChatModel.NotificationsArea = "Las contraseñas no coinciden.";
                return;
            }

            _mainViewModel.ChatViewModel.ChatManager.Register(_tempUsername, _tempPassword);
            _mainViewModel.ChatViewModel.ChatState = ChatState.Chatting;
            _tempPassword = string.Empty;
            _tempUsername = string.Empty;
        }

        public void ChooseUsernameLogin(string message)
        {
            if (!_mainViewModel.ChatViewModel.ChatManager.IsUserRegistered(message))
            {
                _mainViewModel.ChatModel.NotificationsArea = "El usuario no existe.";
                return;
            }

            _mainViewModel.ChatViewModel.ChatState = ChatState.LoginWaitingPassword;
            _tempUsername = message;
        }

        public void ChoosePasswordLogin(string message)
        {
            if (!_mainViewModel.ChatViewModel.ChatManager.IsPasswordCorrect(_tempUsername, message))
            {
                _mainViewModel.ChatViewModel.ChatState = ChatState.LoginWaitingUsername;
                _mainViewModel.ChatModel.NotificationsArea = "Contraseña incorrecta. Introduce tu nombre de usuario.";
                return;
            }

            _mainViewModel.ChatViewModel.ChatManager.Login(_tempUsername, message);
            _mainViewModel.ChatViewModel.ChatState = ChatState.Chatting;
            _tempUsername = string.Empty;
        }

        public void SendMessage(string message)
        {
            _mainViewModel.ChatViewModel.ChatManager.SendMessage(message);            
        }
    }
}
