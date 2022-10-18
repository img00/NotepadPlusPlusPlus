using NotepadPlusPlusPlus.Model;

namespace NotepadPlusPlusPlus.ViewModel.Main.Commands.FileMenu
{
    public class CommandSave : CommandBase
    {
        public override void Execute(object? parameter) => Save();

        public bool Save()
        {
            DocumentModel document = MainViewModel.Document;
            MainViewModel.SwitchView(false);

            if (MainViewModel.Document.Path.Equals(""))
                return CommandSaveAs.SaveAs();

            Save(document.Name, document.Path, MainViewModel.CurrentModel.Text);
            return true;
        }

        public static void Save(string name, string path, string text)
        {
            MainViewModel mainViewModel = App.MainViewModel;
            mainViewModel.Document.Name = name;
            mainViewModel.Document.Path = path;
            mainViewModel.Document.Text = text;
            mainViewModel.Document.Unsaved = false;

            System.IO.File.WriteAllText(path, text, mainViewModel.Document.Encoding);
        }
    }
}
