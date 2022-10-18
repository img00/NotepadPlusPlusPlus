using System.Diagnostics;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.HelpMenu
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
