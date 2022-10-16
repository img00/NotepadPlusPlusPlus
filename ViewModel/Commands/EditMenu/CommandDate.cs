using System;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    internal class CommandDate : CommandBase
    {
        public override void Execute(object? parameter)
        {
            DateTime now = DateTime.Now;
            MainViewModel.CurrentWindowModel.SelectedText = $"{now:t} {now:d}";
            MainViewModel.CurrentWindowModel.SelectionStart += MainViewModel.CurrentWindowModel.SelectionLength;
            MainViewModel.CurrentWindowModel.SelectionLength = 0;
        }
    }
}
