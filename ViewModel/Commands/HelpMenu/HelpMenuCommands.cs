using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.HelpMenu
{
    public class HelpMenuCommands
    {
        public ICommand CmdSeeHelp { get; } = new CommandSeeHelp();
        public ICommand CmdFeedback { get; } = new CommandFeedback();
    }
}
