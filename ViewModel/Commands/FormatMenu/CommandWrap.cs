using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Format
{
    internal class CommandWrap : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.MainWindowModel.TextWrap.Equals(TextWrapping.NoWrap))
                MainViewModel.MainWindowModel.TextWrap = TextWrapping.Wrap;
            else
                MainViewModel.MainWindowModel.TextWrap = TextWrapping.NoWrap;
        }
    }
}
