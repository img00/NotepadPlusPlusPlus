namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.ViewMenu
{
    public class CommandZoomReset : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MainViewModel.WindowModel.ZoomLevel = 1f;
        }
    }
}
