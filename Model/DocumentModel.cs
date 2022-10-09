using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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
                OnPropertyChanged(nameof(Name));
            }
        }
        private string? _path;
        public string Path
        {
            get => _path ?? "";
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
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

        private bool? _unsaved;
        public bool Unsaved
        {
            get => _unsaved ?? false;
            set
            {
                _unsaved = value;
                OnPropertyChanged(nameof(Unsaved));
            }
        }

        private Encoding _encoding;
        public Encoding Encoding
        {
            get => _encoding;
            set
            {
                _encoding = value;
                EncodingString = value.BodyName.ToUpper();
                OnPropertyChanged(nameof(Encoding));
            }
        }

        private string _encodingString;
        public string EncodingString
        {
            get => _encodingString;
            set
            {
                _encodingString = value;
                OnPropertyChanged(nameof(EncodingString));
            }
        }

    }
}
