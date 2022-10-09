using NotepadPlusPlusPlus.Model;
using System;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandNew : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public CommandNew(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            // TODO: This logic is repeated 3 times throught the code (close, open, new). Move to its own method
            // HACK: Message box on vm. Adapt to MVVM
            if (_mainViewModel.Document.Unsaved)
            {
                MessageBoxResult result = MessageBox.Show($"¿Deseas guardar los cambios de {_mainViewModel.Document.Name}?", "Bloc de notas", MessageBoxButton.YesNoCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.Cancel)
                    return;
                if (result == MessageBoxResult.Yes)
                {
                    bool hasSaved = ((CommandSave)_mainViewModel.FileCommands.CmdSave).Save();
                    if (!hasSaved) return;
                }
            }

            _mainViewModel.Document.Name = "";
            _mainViewModel.Document.Path = "";
            _mainViewModel.Document.Text = "";
            _mainViewModel.Document.Encoding = System.Text.Encoding.UTF8;
            _mainViewModel.Document.Unsaved = false;

            _mainViewModel.MainWindow.Text = "";
        }
    }

}
