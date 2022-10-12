using System.Windows;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.ViewModel.Commands.FileMenu
{
    public class CommandPrint : CommandBase
    {
        public override void Execute(object? parameter)
        {
            PrintDialog printDialog = new PrintDialog();
            bool? printed = printDialog.ShowDialog();

            if (printed != true) return;

            // TODO: Implement print
            MessageBox.Show("Imprimir aún no está implementado", "Bloc de notas", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
