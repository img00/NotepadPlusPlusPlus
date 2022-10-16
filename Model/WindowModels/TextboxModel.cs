using System;

namespace NotepadPlusPlusPlus.Model.WindowModels
{
    public abstract class TextboxModel : ObservableObject
    {
        private string? _text;
        public string Text
        {
            get => _text ?? string.Empty;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private string _selectedText = "";
        public string SelectedText
        {
            get => _selectedText;
            set
            {
                _selectedText = value;
                OnPropertyChanged();
            }
        }

        private int _selectionStart;
        public int SelectionStart
        {
            get => _selectionStart;
            set
            {
                _selectionStart = value;
                OnPropertyChanged();
            }
        }

        private int _selectionLength;
        public int SelectionLength
        {
            get => _selectionLength;
            set
            {
                _selectionLength = value;
                OnPropertyChanged();
            }
        }

        private int _caretIndex;
        public int CaretIndex
        {
            get => _caretIndex;
            set
            {
                _caretIndex = value;
                OnPropertyChanged();
            }
        }

        // REMEMBER: Setting lines or columns from from ExtendedTextBox doesn't work if any text is selected. Please deselect all text first.
        private int _line = 0;
        public int Line
        {
            get => _line;
            set
            {
                _line = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LineColFormatted));
            }
        }

        // REMEMBER: Setting lines or columns from from ExtendedTextBox doesn't work if any text is selected. Please deselect all text first.
        private int _column = 0;
        public int Column
        {
            get => _column;
            set
            { 
                _column = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LineColFormatted));
            }
        }

        public string LineColFormatted => $"Línea {Line + 1}, Columna {Column + 1}";

    }
}
