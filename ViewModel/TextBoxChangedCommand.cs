using NotepadPlusPlusPlus.ViewModel.Commands;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class TextBoxChangedCommand : CommandBase
    {
        private MainViewModel _mainViewModel;
        public TextBoxChangedCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            bool unsaved = !_mainViewModel.MainWindow.Text.Equals(_mainViewModel.Document.Text);

            if (_mainViewModel.Document.Unsaved == unsaved) return;

            _mainViewModel.Document.Unsaved = unsaved;
        }
    }
}
