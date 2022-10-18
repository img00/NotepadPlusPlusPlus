using NotepadPlusPlusPlus.Model.WindowModels;
using NotepadPlusPlusPlus.ViewModel.Main;
using NotepadPlusPlusPlus.ViewModel.Main.Commands;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Chat.Commands
{
    public class CommandCutPasteDelete : CommandBase
    {
        private ChatModel _chatModel => MainViewModel.ChatModel;

        public override void Execute(object? parameter)
        {
            if (parameter == null) return;

            ExecutedRoutedEventArgs e = (ExecutedRoutedEventArgs)parameter;

            if (_chatModel.SelectionStart < _chatModel.ChatAreaStart)
            {
                if (e.Command.Equals(ApplicationCommands.Cut))
                {
                    ApplicationCommands.Copy.Execute(null, null);
                    e.Handled = true;
                    return;
                }

                ChatViewModel.MoveCursorChatArea();
            }

            if (e.Command.Equals(ApplicationCommands.Cut))
            {
                Cut();
            }
            else if (e.Command.Equals(ApplicationCommands.Paste))
            {
                Paste();
            }
            else if (e.Command.Equals(EditingCommands.Delete))
            {
                Delete();
            }

            e.Handled = true;
        }

        private void Cut()
        {
            Clipboard.SetText(_chatModel.SelectedText);
            _chatModel.SelectedText = string.Empty;
        }

        private void Paste()
        {
            _chatModel.SelectedText = Clipboard.GetText();
            _chatModel.SelectionStart += _chatModel.SelectionLength;
            _chatModel.SelectionLength = 0;
        }

        private void Delete()
        {
            if (_chatModel.SelectionLength > 0)
                _chatModel.SelectedText = string.Empty;
            else
            {
                _chatModel.SelectionLength += 1;
                _chatModel.SelectedText = string.Empty;
                _chatModel.SelectionLength = 0;
            }
        }

        public override bool CanExecute(object? parameter) => MainViewModel.WindowModel.IsChatting;
    }
}
