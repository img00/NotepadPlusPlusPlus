using Microsoft.Win32;
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
            Save(_mainViewModel);
        }

        public static void Save(MainViewModel mainViewModel)
        {
            if (mainViewModel.File.Path.Equals(""))
                CommandSaveAs.SaveAsDialog(mainViewModel.TextBoxText, mainViewModel);
            else
            {
                System.IO.File.WriteAllText(mainViewModel.File.Path, mainViewModel.TextBoxText);
                mainViewModel.File = new Model.File(mainViewModel.File.Name, mainViewModel.File.Path, mainViewModel.TextBoxText);
            }
        }
    }

}
