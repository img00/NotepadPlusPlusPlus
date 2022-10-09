using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandClose : CommandBase
    {
        private MainViewModel _mainViewModel;

        public CommandClose(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter) => _mainViewModel.Close?.Invoke();

        public bool CanClose()
        {
            // TODO: This logic is repeated 3 times throught the code (close, open, new). Move to its own method
            // HACK: Message box on vm. Adapt to MVVM
            if (_mainViewModel.Document.Unsaved)
            {
                MessageBoxResult result = MessageBox.Show($"¿Deseas guardar los cambios de {_mainViewModel.Document.Name}?", "Bloc de notas", MessageBoxButton.YesNoCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.Cancel)
                    return false;
                if (result == MessageBoxResult.Yes)
                {
                    bool hasSaved = ((CommandSave)_mainViewModel.FileCommands.CmdSave).Save();
                    if (!hasSaved) return false;
                }
            }

            return true;
        }

    }

}
