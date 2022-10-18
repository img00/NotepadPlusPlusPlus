using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.FileMenu
{
    public class CommandClose : CommandBase
    {
        public override void Execute(object? parameter) => MainViewModel.Close?.Invoke();

        public bool CanClose()
        {
            // TODO: This logic is repeated 3 times throught the code (close, open, new). Move to its own method
            // HACK: Message box on vm. Adapt to MVVM
            if (MainViewModel.Document.Unsaved)
            {
                MessageBoxResult result = MessageBox.Show($"¿Deseas guardar los cambios de {MainViewModel.Document.Name}?", "Bloc de notas", MessageBoxButton.YesNoCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.Cancel)
                    return false;
                if (result == MessageBoxResult.Yes)
                {
                    bool hasSaved = ((CommandSave)MainViewModel.FileCommands.CmdSave).Save();
                    if (!hasSaved) return false;
                }
            }

            return true;
        }

    }

}
