namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomOut : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindow.ZoomLevel > MainViewModel.MainWindow.MinZoomLevel)
                MainViewModel.MainWindow.ZoomLevel -= 0.1f;
        }
    }
}
