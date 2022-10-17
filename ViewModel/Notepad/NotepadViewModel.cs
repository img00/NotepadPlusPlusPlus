using NotepadPlusPlusPlus.Model.WindowModels;
using NotepadPlusPlusPlus.ViewModel.Main;

namespace NotepadPlusPlusPlus.ViewModel.Notepad
{
    public class NotepadViewModel
    {
        private readonly MainViewModel _mainViewModel = App.MainViewModel;

        public void SwitchToNotepadView()
        {
            App.ChatView.IsEnabled = false;
            App.NotepadView.IsEnabled = true;

            _mainViewModel.CurrentViewModel = App.NotepadViewModel;
            _mainViewModel.WindowModel.CurrentView = App.NotepadView;
            _mainViewModel.CurrentModel = _mainViewModel.NotepadModel;
            _mainViewModel.WindowModel.IsChatting = false;
        }
    }
}
