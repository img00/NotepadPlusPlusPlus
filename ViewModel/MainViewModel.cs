using NotepadPlusPlusPlus.ViewModel.Commands;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand CmdNew { get; } = new CommandNew();
        public ICommand CmdOpen { get; } = new CommandOpen();
        public ICommand CmdSave { get; } = new CommandSave();
        public ICommand CmdSaveAs { get; } = new CommandSaveAs();
        public ICommand CmdClose { get; }

        public MainViewModel()
        {
            CmdClose = new CommandClose(this);
        }

        private string _texto;
        public string Texto
        {
            get
            {
                return _texto;
            }
            set
            {
                _texto = value;
                OnPropertyChanged(nameof(Texto));
            }
        }

    }

}
