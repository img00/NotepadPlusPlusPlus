using NotepadPlusPlusPlus.ViewModel.Main.Commands;

namespace NotepadPlusPlusPlus.ViewModel.Chat.Commands
{
    public class CommandSwitch : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MainViewModel.SwitchView(!MainViewModel.WindowModel.IsChatting);
        }
    }
}
