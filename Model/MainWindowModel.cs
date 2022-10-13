using System;
using System.Windows;

namespace NotepadPlusPlusPlus.Model
{
    public class MainWindowModel : ObservableObject
    {

        public MainWindowModel()
        {
            FontSize = 14;
            ZoomLevel = 1;
            TextWrap = TextWrapping.NoWrap;
            StatusBar = Visibility.Visible;
            LineColFormatted = "Línea 1, Columna 1";
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string? _displayedText;
        public string DisplayedText
        {
            get => _displayedText ?? "";
            set
            {
                _displayedText = value;
                OnPropertyChanged(nameof(DisplayedText));
            }
        }

        private string _selectedText;
        public string SelectedText
        {
            get => _selectedText;
            set
            {
                _selectedText = value;
                OnPropertyChanged(nameof(SelectedText));
            }
        }

        private int _selectionStart;
        public int SelectionStart
        {
            get => _selectionStart;
            set
            {
                _selectionStart = value;
                OnPropertyChanged(nameof(SelectionStart));
            }
        }

        // TODO: There is a better way to do this. This method lags when the ammount of text is really big. Instead,
        // the lines should be cached into an list to make calculations much faster.
        // See https://referencesource.microsoft.com/#PresentationFramework/src/Framework/MS/Internal/Documents/TextBoxView.cs,4f9eac8044eb0868 : GetLineIndexFromCharacterIndex
        private int _lastCaretBeforeSelection;
        private int _caretIndex;
        public int CaretIndex
        {
            get => _caretIndex;
            set
            {
                if (SelectionLength == 0) _lastCaretBeforeSelection = value;
                _caretIndex = value;
                OnPropertyChanged(nameof(CaretIndex));
                
                // This line is important because the caret stays at the lowest index of the selection,
                // so we need to increase it by the length if going to the right to show the correct column
                int caretPosWithLength = _lastCaretBeforeSelection > value ? value : value + SelectionLength;

                int index = -1;
                int currentLineStart = 0;
                int rows = 1;
                string substring = caretPosWithLength > 2 ? DisplayedText[..caretPosWithLength] : DisplayedText;
                while ((index = substring.IndexOf(Environment.NewLine, index + 1)) != -1 && index < caretPosWithLength)
                {
                    currentLineStart = index + Environment.NewLine.Length;
                    rows++;
                }

                int columns = caretPosWithLength - currentLineStart + 1;

                LineColFormatted = $"Línea {rows}, Columna {columns}";
            }
        }

        private string _lineColFormatted;
        public string LineColFormatted
        {
            get => _lineColFormatted;
            set
            {
                _lineColFormatted = value;
                OnPropertyChanged(nameof(LineColFormatted));
            }
        }

        private int _selectionLength;
        public int SelectionLength
        {
            get => _selectionLength;
            set
            {
                _selectionLength = value;
                OnPropertyChanged(nameof(SelectionLength));
            }
        }


        private int _fontSize;
        public int FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                FontSizeWithZoom = value * ZoomLevel;
                OnPropertyChanged(nameof(FontSize));
            }
        }


        public readonly float MaxZoomLevel = 5;
        public readonly float MinZoomLevel = 0.1f;
        private float _zoomLevel;
        public float ZoomLevel
        {
            get => _zoomLevel;
            set
            {
                _zoomLevel = (float)Math.Round(value, 1);
                ZoomLevelFormatted = (int)Math.Round(_zoomLevel * 100f) + "%";
                FontSizeWithZoom = value * FontSize;
                OnPropertyChanged(nameof(ZoomLevel));
            }
        }

        private string _zoomLevelFormatted;
        public string ZoomLevelFormatted
        {
            get => _zoomLevelFormatted;
            set
            {
                _zoomLevelFormatted = value;
                OnPropertyChanged(nameof(ZoomLevelFormatted));
            }
        }

        private float _fontSizeWithZoom;
        public float FontSizeWithZoom
        {
            get => _fontSizeWithZoom;
            set
            {
                _fontSizeWithZoom = value;
                OnPropertyChanged(nameof(FontSizeWithZoom));
            }
        }

        private TextWrapping _textWrap;
        public TextWrapping TextWrap
        {
            get => _textWrap;
            set
            {
                _textWrap = value;
                OnPropertyChanged(nameof(TextWrap));
            }
        }

        private Visibility _statusBar;
        public Visibility StatusBar
        {
            get => _statusBar;
            set
            {
                _statusBar = value;
                OnPropertyChanged(nameof(StatusBar));
            }
        }

        private bool _isChatting;
        public bool IsChatting
        {
            get => _isChatting;
            set
            {
                _isChatting = value;
                OnPropertyChanged(nameof(IsChatting));
            }
        }

    }
}
