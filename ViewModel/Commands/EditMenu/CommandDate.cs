using System;


namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    internal class CommandDate : CommandBase
    {
        public override void Execute(object? parameter)
        {
            System.Windows.Controls.TextBox? textBox = parameter as System.Windows.Controls.TextBox;
            if (textBox != null)
            {
                DateTime now = DateTime.Now;
                textBox.SelectedText = $"{now:t} {now:d}";
                textBox.Select(textBox.SelectionStart + textBox.SelectionLength, 0);
            }
        }
    }
}
