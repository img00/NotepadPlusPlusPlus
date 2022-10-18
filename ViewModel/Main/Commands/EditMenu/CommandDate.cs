using System;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.EditMenu
{
    internal class CommandDate : CommandBase
    {
        public override void Execute(object? parameter)
        {
            DateTime now = DateTime.Now;
            MainViewModel.CurrentModel.SelectedText = $"{now:t} {now:d}";
            MainViewModel.CurrentModel.SelectionStart += MainViewModel.CurrentModel.SelectionLength;
            MainViewModel.CurrentModel.SelectionLength = 0;
        }
    }
}
