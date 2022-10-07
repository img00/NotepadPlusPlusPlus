using NotepadPlusPlusPlus.ViewModel.Commands.Edit;
using NotepadPlusPlusPlus.ViewModel.Commands.File;
using System;
using System.Runtime.CompilerServices;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public FileCommands FileCommands { get; set; }
        public EditCommands EditCommands { get; set; }

        public MainViewModel()
        {
            File = new Model.File();

            FileCommands = new FileCommands(this);
            EditCommands = new EditCommands(this);
        }

        private string? _textBoxText;
        public string TextBoxText
        {
            get => _textBoxText ?? "";
            set
            {
                _textBoxText = value;
                OnPropertyChanged(nameof(TextBoxText));

                if (value == null) return;

                File.Unsaved = !value.Equals(File.Text);

                if (File.Unsaved)
                {
                    if (!WindowTitle.StartsWith('*'))
                        WindowTitle = '*' + WindowTitle;
                }
                else
                    WindowTitle = WindowTitle.StartsWith('*') ? WindowTitle[1..] : WindowTitle;
            }
        }

        private Model.File? _file;
        public Model.File File
        {
            get => _file ?? new Model.File();
            set
            {
                _file = value;
                OnPropertyChanged(nameof(File));
                WindowTitle = $"{File.Name}: Bloc de notas";
            }
        }

        private string? _windowTitle;
        public string WindowTitle
        {
            get => _windowTitle ?? "";
            set
            {
                _windowTitle = value;
                OnPropertyChanged(nameof(WindowTitle));
            }
        }

    }
}
