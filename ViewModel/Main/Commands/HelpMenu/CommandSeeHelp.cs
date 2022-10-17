using System.Diagnostics;

namespace NotepadPlusPlusPlus.ViewModel.Commands.HelpMenu
{
    public class CommandSeeHelp : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string link = "https://www.google.com/search?q=obtener ayuda con el bloc de notas en Windows 10";
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }
    }
}
