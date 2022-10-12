using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Format
{
    internal class CommandWrap : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindow.TextWrap.Equals(TextWrapping.NoWrap))
                MainViewModel.MainWindow.TextWrap = TextWrapping.Wrap;
            else
                MainViewModel.MainWindow.TextWrap = TextWrapping.NoWrap;
        }
    }
}
