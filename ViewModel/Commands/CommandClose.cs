using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands
{
    public class CommandClose : CommandBase
    {
        MainViewModel m;

        public CommandClose(MainViewModel m)
        {
            this.m = m;
        }

        public override void Execute(object? parameter)
        {
            //TODO: Close logic, needs to check if has been saved
            Window? window = parameter as Window;
            if (window != null)
                //window.Close();
                m.Texto = "ASDFFASF";
        }
    }

}
