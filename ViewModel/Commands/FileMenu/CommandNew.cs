using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandNew : CommandBase
    {
        public override void Execute(object? parameter)
        {
            // TODO: This logic is repeated 3 times throught the code (close, open, new). Move to its own method
            // HACK: Message box on vm. Adapt to MVVM
            if (MainViewModel.Document.Unsaved)
            {
                MessageBoxResult result = MessageBox.Show($"¿Deseas guardar los cambios de {MainViewModel.Document.Name}?", "Bloc de notas", MessageBoxButton.YesNoCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.Cancel)
                    return;
                if (result == MessageBoxResult.Yes)
                {
                    bool hasSaved = ((CommandSave)MainViewModel.FileCommands.CmdSave).Save();
                    if (!hasSaved) return;
                }
            }

            MainViewModel.Document.Name = "";
            MainViewModel.Document.Path = "";
            MainViewModel.Document.Text = "";
            MainViewModel.Document.Encoding = System.Text.Encoding.UTF8;
            MainViewModel.Document.Unsaved = false;

            MainViewModel.CurrentWindowModel.Text = "";
        }
    }

}
