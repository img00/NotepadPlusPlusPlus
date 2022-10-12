namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomIn : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindow.ZoomLevel < MainViewModel.MainWindow.MaxZoomLevel)
                MainViewModel.MainWindow.ZoomLevel += 0.1f;
        }
    }
}
