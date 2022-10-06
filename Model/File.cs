
namespace NotepadPlusPlusPlus.Model
{
    public class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Text { get; set; }

        public bool Unsaved = false;


        public File(string name, string path, string text)
        {
            Name = name;
            Path = path;
            Text = text;
        }

        public File()
        {
            Name = "Sin título";
            Path = "";
            Text = "";
        }
    }
}
