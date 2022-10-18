using System.Windows;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.FileMenu
{
    public class CommandPrint : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MainViewModel.SwitchView(false);

            bool? printed = new PrintDialog().ShowDialog();

            if (printed != true) return;

            // TODO: Implement print
            MessageBox.Show("Imprimir aún no está implementado", "Bloc de notas", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
