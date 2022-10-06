using System;
using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandNew : CommandBase
    {
        private MainViewModel _mainViewModel;

        public CommandNew(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (!_mainViewModel.TextBoxText.Equals(_mainViewModel.File.Text))
            {
                MessageBoxResult result = MessageBox.Show($"¿Deseas guardar los cambios de {_mainViewModel.File.Name}?", "Bloc de notas", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Cancel)
                    return;
                if (result == MessageBoxResult.Yes)
                    CommandSave.Save(_mainViewModel);
            }

            _mainViewModel.File = new Model.File();
            _mainViewModel.TextBoxText = "";
        }
    }

}
