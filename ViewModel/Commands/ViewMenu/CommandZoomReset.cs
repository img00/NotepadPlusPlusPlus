namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomReset : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MainViewModel.MainWindow.ZoomLevel = 1f;
        }
    }
}
