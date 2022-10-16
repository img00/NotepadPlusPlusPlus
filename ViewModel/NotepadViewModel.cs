using NotepadPlusPlusPlus.Model.WindowModels;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class NotepadViewModel
    {
        private readonly MainViewModel _mainViewModel = App.MainViewModel;

        public void SwitchToNotepadView()
        {
            App.ChatView.IsEnabled = false;
            App.NotepadView.IsEnabled = true;

            _mainViewModel.CurrentViewModel = App.NotepadViewModel;
            _mainViewModel.MainWindowModel.CurrentView = App.NotepadView;
            _mainViewModel.CurrentWindowModel = _mainViewModel.NotepadWindowModel;
            _mainViewModel.MainWindowModel.IsChatting = false;
        }
    }
}
