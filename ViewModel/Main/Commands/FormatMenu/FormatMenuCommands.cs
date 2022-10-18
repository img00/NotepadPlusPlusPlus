using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.FormatMenu
{
    public class FormatMenuCommands
    {
        public ICommand CmdWrap { get; } = new CommandWrap();
    }
}
