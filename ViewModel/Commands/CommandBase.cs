using System;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected MainViewModel MainViewModel => App.MainViewModel;

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

        protected void OnCanExecuteChanged() => _canExecuteChanged?.Invoke(this, new EventArgs());
    }
}
