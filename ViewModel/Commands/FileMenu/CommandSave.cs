using Microsoft.Win32;
using NotepadPlusPlusPlus.Model;
using System;
using System.Linq;
using System.Windows;

namespace NotepadPlusPlusPlus.ViewModel.Commands.File
{
    public class CommandSave : CommandBase
    {
        private MainViewModel _mainViewModel;

        public CommandSave(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            Save();
        }

        public bool Save()
        {
            DocumentModel document = _mainViewModel.Document;

            if (_mainViewModel.Document.Path.Equals(""))
                return CommandSaveAs.SaveAs(_mainViewModel);

            Save(_mainViewModel, document.Name, document.Path, _mainViewModel.MainWindow.Text);
            return true;
        }

        public static void Save(MainViewModel mainViewModel, string name, string path, string text)
        {
            mainViewModel.Document.Name = name;
            mainViewModel.Document.Path = path;
            mainViewModel.Document.Text = text;
            mainViewModel.Document.Unsaved = false;

            System.IO.File.WriteAllText(path, text, mainViewModel.Document.Encoding);
        }
    }

}
