using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.FormatMenu
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
