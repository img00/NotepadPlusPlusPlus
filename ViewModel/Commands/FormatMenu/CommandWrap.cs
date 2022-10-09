using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Format
{
    internal class CommandWrap : CommandBase
    {
        private MainViewModel _mainViewModel;

        public CommandWrap(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainViewModel.MainWindow.TextWrap.Equals(TextWrapping.NoWrap))
                _mainViewModel.MainWindow.TextWrap = TextWrapping.Wrap;
            else
                _mainViewModel.MainWindow.TextWrap = TextWrapping.NoWrap;
        }
    }
}
