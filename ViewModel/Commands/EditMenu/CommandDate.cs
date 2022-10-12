using System;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    internal class CommandDate : CommandBase
    {
        public override void Execute(object? parameter)
        {
            DateTime now = DateTime.Now;
            MainViewModel.MainWindow.SelectedText = $"{now:t} {now:d}";
            MainViewModel.MainWindow.SelectionStart += MainViewModel.MainWindow.SelectionLength;
            MainViewModel.MainWindow.SelectionLength = 0;
        }
    }
}
