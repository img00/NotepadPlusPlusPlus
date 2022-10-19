using System;

namespace NotepadPlusPlusPlus.ViewModel.Chat
{
    public abstract class ChatState
    {
        public static readonly ChatState ConnectionFailed = new ConnectionFailedState();
        public static readonly ChatState WaitingRegisterLogin = new WaitingRegisterLoginState();
        public static readonly ChatState RegisterWaitingUsername = new RegisterWaitingUsernameState();
        public static readonly ChatState RegisterWaitingPassword = new RegisterWaitingPasswordState();
        public static readonly ChatState RegisterWaitingPasswordConfirmation = new RegisterWaitingPasswordConfirmationState();
        public static readonly ChatState LoginWaitingUsername = new LoginWaitingUsernameState();
        public static readonly ChatState LoginWaitingPassword = new LoginWaitingPasswordState();
        public static readonly ChatState Chatting = new ChattingState();


        public abstract void OnSendMessage(string message);
        public abstract string NotificationMessage { get; }

        private class ConnectionFailedState : ChatState
        {
            public override string NotificationMessage => "No se ha podido conectar con el chat. Por favor inténtalo más tarde.";
            public override void OnSendMessage(string message) { }
        }

        private class WaitingRegisterLoginState : ChatState
        {
            public override string NotificationMessage => "Envía (1) para iniciar sesión. Envía (2) para registrarte.";

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.ChooseRegisterLogin(message);
        }

        private class RegisterWaitingUsernameState : ChatState
        {
            public override string NotificationMessage => "Introduce tu nombre de usuario.";

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.ChooseUsernameRegister(message);
        }

        private class RegisterWaitingPasswordState : ChatState
        {
            public override string NotificationMessage => "Introduce tu contraseña.";

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.ChoosePasswordRegister(message);
        }

        private class RegisterWaitingPasswordConfirmationState : ChatState
        {
            public override string NotificationMessage => "Vuelve a introducir tu contraseña";

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.ChoosePasswordConfirmationRegister(message);
        }

        private class LoginWaitingUsernameState : ChatState
        {
            public override string NotificationMessage => "Introduce tu nombre de usuario.";

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.ChooseUsernameLogin(message);
        }

        private class LoginWaitingPasswordState : ChatState
        {
            public override string NotificationMessage => "Introduce tu contraseña.";

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.ChoosePasswordLogin(message);
        }

        private class ChattingState : ChatState
        {
            public override string NotificationMessage => string.Empty;

            public override void OnSendMessage(string message) => App.ChatViewModel?.ChatMessageSentActions.SendMessage(message);
        }
    }

}
