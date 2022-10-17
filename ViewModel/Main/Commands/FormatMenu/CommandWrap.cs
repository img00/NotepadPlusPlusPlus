using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Format
{
    internal class CommandWrap : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (MainViewModel.WindowModel.TextWrap.Equals(TextWrapping.NoWrap))
                MainViewModel.WindowModel.TextWrap = TextWrapping.Wrap;
            else
                MainViewModel.WindowModel.TextWrap = TextWrapping.NoWrap;
        }
    }
}
