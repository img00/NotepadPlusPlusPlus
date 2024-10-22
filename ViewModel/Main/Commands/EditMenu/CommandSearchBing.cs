﻿using System.Diagnostics;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.EditMenu
{
    public class CommandSearchBing : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string link = "https://www.google.com/search?q=" + MainViewModel.CurrentModel.SelectedText;
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }

        public override bool CanExecute(object? parameter) =>
            MainViewModel.CurrentModel.SelectionLength > 0;
    }
}
