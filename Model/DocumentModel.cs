using System.Text;

namespace NotepadPlusPlusPlus.Model
{
    public class DocumentModel : ObservableObject
    {

        public DocumentModel()
        {
            Name = "";
            Path = "";
            Text = "";
            Encoding = Encoding.UTF8;
        }

        private string? _name;
        public string Name
        {
            get => _name ?? "";
            set
            {
                _name = !value.Equals("") ? value : "Sin título";
                OnPropertyChanged();
            }
        }
        private string? _path;
        public string Path
        {
            get => _path ?? "";
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        private string? _text;
        public string Text
        {
            get => _text ?? "";
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private bool? _unsaved;
        public bool Unsaved
        {
            get => _unsaved ?? false;
            set
            {
                _unsaved = value;
                OnPropertyChanged();
            }
        }

        private Encoding _encoding;
        public Encoding Encoding
        {
            get => _encoding;
            set
            {
                _encoding = value;
                OnPropertyChanged();
                OnPropertyChanged(EncodingString);
            }
        }

        public string EncodingString => Encoding.BodyName.ToUpper();

    }
}
