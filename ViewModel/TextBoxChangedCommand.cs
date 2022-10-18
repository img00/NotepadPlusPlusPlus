using NotepadPlusPlusPlus.ViewModel.Main.Commands;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class TextBoxChangedCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            bool unsaved = !MainViewModel.NotepadModel.Text.Equals(MainViewModel.Document.Text);

            if (MainViewModel.Document.Unsaved == unsaved) return;

            MainViewModel.Document.Unsaved = unsaved;
        }
    }
}
