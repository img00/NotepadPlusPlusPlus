using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    internal class CommandDate : CommandBase
    {
        public override void Execute(object? parameter)
        {
            TextBox? textBox = parameter as TextBox;
            if (textBox != null)
            {
                DateTime now = DateTime.Now;
                textBox.SelectedText = $"{now:t} {now:d}";
                textBox.Select(textBox.SelectionStart + textBox.SelectionLength, 0);
            }
        }
    }
}
