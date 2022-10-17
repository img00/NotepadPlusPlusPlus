namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomOut : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.WindowModel.ZoomLevel > MainViewModel.WindowModel.MinZoomLevel)
                MainViewModel.WindowModel.ZoomLevel -= 0.1f;
        }
    }
}
