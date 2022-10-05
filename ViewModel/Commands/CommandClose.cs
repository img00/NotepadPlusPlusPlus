using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands
{
    public class CommandClose : CommandBase
    {
        public override void Execute(object? parameter)
        {
            //TODO: Close logic, needs to check if has been saved
            Window? window = parameter as Window;
            if (window != null)
                window.Close();
        }
    }

}
