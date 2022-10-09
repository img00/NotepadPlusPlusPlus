using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadPlusPlusPlus.Model
{
    public class MainWindowModel : ObservableObject
    {

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

    }
}
