using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Format
{
    public class FormatMenuCommands
    {
        public ICommand CmdWrap { get; } = new CommandWrap();
    }
}
