using System;
using System.Windows;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.Model
{
    public class WindowModel : ObservableObject
    {

        public WindowModel()
        {
            FontSize = 14;
            ZoomLevel = 1;
            TextWrap = TextWrapping.NoWrap;
            StatusBar = Visibility.Visible;
        }

        // TODO: Do this correctly. The title should be changed by the ViewModel, not here
        private string _title;
        public string Title
        {
            get => !IsChatting ? _title : "Chat: Bloc de notas";
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private int _fontSize;
        public int FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FontSizeWithZoom));
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(ZoomLevelFormatted));
                OnPropertyChanged(nameof(FontSizeWithZoom));
            }
        }

        public string ZoomLevelFormatted => (int)Math.Round(ZoomLevel * 100f) + "%";

        public float FontSizeWithZoom => ZoomLevel * FontSize;


        private TextWrapping _textWrap;
        public TextWrapping TextWrap
        {
            get => _textWrap;
            set
            {
                _textWrap = value;
                OnPropertyChanged();
            }
        }

        private Visibility _statusBar;
        public Visibility StatusBar
        {
            get => _statusBar;
            set
            {
                _statusBar = value;
                OnPropertyChanged();
            }
        }

        private bool _isChatting;
        public bool IsChatting
        {
            get => _isChatting;
            set
            {
                _isChatting = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

    }
}
