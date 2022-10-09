using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    internal class CommandSearchBing : CommandBase
    {
        //TODO: Do not search if nothing is selected
        public override void Execute(object? parameter)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://youtu.be/dQw4w9WgXcQ");
        }
    }
}
