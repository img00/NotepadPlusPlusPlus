using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotepadPlusPlusPlus.Model
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public virtual void Dispose() { }
    }
}
