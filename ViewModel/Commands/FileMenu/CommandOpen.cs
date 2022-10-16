using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandOpen : CommandBase
    {
        public override void Execute(object? parameter)
        {
            // TODO: This logic is repeated 3 times throught the code (close, open, new). Move to its own method
            // HACK: Message box on vm. Adapt to MVVM
            if (MainViewModel.Document.Unsaved)
            {
                MessageBoxResult result = MessageBox.Show($"¿Deseas guardar los cambios de {MainViewModel.Document.Name}?", "Bloc de notas", MessageBoxButton.YesNoCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.Cancel)
                    return;
                if (result == MessageBoxResult.Yes)
                {
                    bool hasSaved = ((CommandSave)MainViewModel.FileCommands.CmdSave).Save();
                    if (!hasSaved) return;
                }
            }

            Open();
        }

        private void Open()
        {
            // HACK: Open dialog on vm. Adapt to MVVM
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == false) return;

            MainViewModel.Document.Name = openFileDialog.SafeFileName;
            MainViewModel.Document.Path = openFileDialog.FileName;
            String newText = System.IO.File.ReadAllText(openFileDialog.FileName);
            MainViewModel.Document.Text = newText;
            MainViewModel.CurrentWindowModel.Text = newText;
            MainViewModel.Document.Encoding = GetDocumentEncoding(openFileDialog.FileName);
            MainViewModel.Document.Unsaved = false;
        }

        private static Encoding GetDocumentEncoding(string filePath)
        {
            // Reads the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

#pragma warning disable SYSLIB0001 // Type or member is obsolete
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
#pragma warning restore SYSLIB0001 // Type or member is obsolete
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0) return Encoding.UTF32;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode;
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode;
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return new UTF32Encoding(true, true);

            // In case the correct encoding can't be found, return ASCII as a last resort
            return Encoding.ASCII;
        }
    }

}
