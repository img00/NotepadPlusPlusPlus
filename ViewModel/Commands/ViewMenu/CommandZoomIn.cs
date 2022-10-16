namespace NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu
{
    public class CommandZoomIn : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindowModel.ZoomLevel < MainViewModel.MainWindowModel.MaxZoomLevel)
                MainViewModel.MainWindowModel.ZoomLevel += 0.1f;
        }
    }
}
