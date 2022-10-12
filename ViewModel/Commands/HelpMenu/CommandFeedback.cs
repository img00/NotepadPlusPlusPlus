using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadPlusPlusPlus.ViewModel.Commands.HelpMenu
{
    public class CommandFeedback : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string link = "windows-feedback:?contextid=1010";
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }
    }
}
