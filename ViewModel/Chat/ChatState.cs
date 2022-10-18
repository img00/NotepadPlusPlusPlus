using System;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public abstract class ChatState
    {
        public static readonly ChatState ConnectionFailed = new ConnectionFailedState();
        public static readonly ChatState WaitingRegisterLogin = new WaitingRegisterLoginState();
        public static readonly ChatState RegisterWaitingUsername = new RegisterWaitingUsernameState();
        public static readonly ChatState RegistarWaitingPassword = new RegisterWaitingPasswordState();
        public static readonly ChatState RegisterWaitingPasswordConfirmation = new RegisterWaitingPasswordConfirmationState();
        public static readonly ChatState LoginWaitingUsername = new LoginWaitingUsernameState();
        public static readonly ChatState LoginWaitingPassword = new LoginWaitingPasswordState();
        public static readonly ChatState Chatting = new ChattingState();


        public abstract void SendMessage(string message);
        public abstract string NotificationMessage { get; }

        private class ConnectionFailedState : ChatState
        {
            public override string NotificationMessage => "No se ha podido conectar con el chat. Por favor inténtalo más tarde.";
            public override void SendMessage(string message) => throw new NotImplementedException();
        }

        private class WaitingRegisterLoginState : ChatState
        {
            public override string NotificationMessage => "Envía (1) para iniciar sesión. Envía (2) para registrarte.";

            public override void SendMessage(string message) => App.ChatViewModel.ChatMessageSentActions.ChooseRegisterLogin(message);
        }

        private class RegisterWaitingUsernameState : ChatState
        {
            public override string NotificationMessage => "Introduce tu nombre de usuario.";

            public override void SendMessage(string message) => App.ChatViewModel.ChatMessageSentActions.ChooseUsernameRegister(message);
        }

        private class RegisterWaitingPasswordState : ChatState
        {
            public override string NotificationMessage => "Introduce tu contraseña.";

            public override void SendMessage(string message) => throw new NotImplementedException();
        }

        private class RegisterWaitingPasswordConfirmationState : ChatState
        {
            public override string NotificationMessage => "Vuelve a introducir tu contraseña";

            public override void SendMessage(string message) => throw new NotImplementedException();
        }

        private class LoginWaitingUsernameState : ChatState
        {
            public override string NotificationMessage => "Introduce tu nombre de usuario.";

            public override void SendMessage(string message) => throw new NotImplementedException();
        }

        private class LoginWaitingPasswordState : ChatState
        {
            public override string NotificationMessage => "Introduce tu contraseña.";

            public override void SendMessage(string message) => throw new NotImplementedException();
        }

        private class ChattingState : ChatState
        {
            public override string NotificationMessage => string.Empty;

            public override void SendMessage(string message) => throw new NotImplementedException();
        }
    }

}
