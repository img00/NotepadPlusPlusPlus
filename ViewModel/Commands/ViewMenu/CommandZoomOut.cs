namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomOut : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindowModel.ZoomLevel > MainViewModel.MainWindowModel.MinZoomLevel)
                MainViewModel.MainWindowModel.ZoomLevel -= 0.1f;
        }
    }
}
