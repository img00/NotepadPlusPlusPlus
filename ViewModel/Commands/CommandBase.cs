using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands
{
    public abstract class CommandBase : ICommand
    {
        private EventHandler? _canExecuteChanged;
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                _canExecuteChanged += value;
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                _canExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged()
        {
            _canExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
