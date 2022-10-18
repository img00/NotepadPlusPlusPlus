using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.ViewMenu
{
    public class ViewMenuCommands
    {
        public ICommand CmdStatusBar { get; } = new CommandStatusBar();
        public ICommand CmdZoomIn { get; } = new CommandZoomIn();
        public ICommand CmdZoomOut { get; } = new CommandZoomOut();
        public ICommand CmdZoomReset { get; } = new CommandZoomReset();
    }
}
