namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.ViewMenu
{
    public class CommandZoomIn : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.WindowModel.ZoomLevel < MainViewModel.WindowModel.MaxZoomLevel)
                MainViewModel.WindowModel.ZoomLevel += 0.1f;
        }
    }
}
