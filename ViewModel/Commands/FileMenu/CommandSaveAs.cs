using Microsoft.Win32;
using NotepadPlusPlusPlus.Model;
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

        public override void Execute(object? parameter)
        {
            SaveAs(_mainViewModel);
        }

        public static bool SaveAs(MainViewModel mainViewModel)
        {
            // HACK: Save dialog on vm. Adapt to MVVM
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            
            if (saveFileDialog.ShowDialog() == false) return false;

            CommandSave.Save(mainViewModel, saveFileDialog.SafeFileName, saveFileDialog.FileName, mainViewModel.MainWindow.Text);
            return true;
        }


    }

}
