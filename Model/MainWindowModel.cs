using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private string? _title;
        public string Title
        {
            get => _title ?? "";
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string? _text;
        public string Text
        {
            get => _text ?? "";
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
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
                _zoomLevel = (float) Math.Round(value, 1);
                ZoomLevelFormatted = (int) Math.Round(_zoomLevel * 100f) + "%";
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

    }
}
