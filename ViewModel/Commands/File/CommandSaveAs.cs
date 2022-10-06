using Microsoft.Win32;
using System;
using System.IO;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandSaveAs : CommandBase
    {

        private MainViewModel _mainViewModel;

        public CommandSaveAs(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        //TODO: Save as logic
        public override void Execute(object? parameter)
        {
            SaveAsDialog(_mainViewModel.TextBoxText ?? "", _mainViewModel);
        }

        public static void SaveAsDialog(String textToSave, MainViewModel model)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            
            if (saveFileDialog.ShowDialog() == false) return;


            Model.File file = new Model.File(saveFileDialog.SafeFileName, saveFileDialog.FileName, textToSave);
            System.IO.File.WriteAllText(file.Path, textToSave);
            model.File = file;

        }


    }

}
