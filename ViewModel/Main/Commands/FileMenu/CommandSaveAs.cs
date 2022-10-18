using Microsoft.Win32;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.FileMenu
{
    public class CommandSaveAs : CommandBase
    {
        public override void Execute(object? parameter)
        {
            SaveAs();
        }

        public static bool SaveAs()
        {
            MainViewModel mainViewModel = App.MainViewModel;

            // HACK: Save dialog on vm. Adapt to MVVM
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == false) return false;

            CommandSave.Save(saveFileDialog.SafeFileName, saveFileDialog.FileName, mainViewModel.CurrentModel.Text);
            return true;
        }


    }

}
