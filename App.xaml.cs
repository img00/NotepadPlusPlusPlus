using NotepadPlusPlusPlus.Model.WindowModels;
using NotepadPlusPlusPlus.View;
using NotepadPlusPlusPlus.ViewModel.Chat;
using NotepadPlusPlusPlus.ViewModel.Main;
using NotepadPlusPlusPlus.ViewModel.Notepad;
using System.Windows;

/* 
 * To publish as single file, use 
 * dotnet publish -c Release -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "./bin/publish"
 */

namespace NotepadPlusPlusPlus
{
    public partial class App : Application
    {
        public static NotepadView NotepadView = new();
        public static ChatView ChatView = new();

        public static MainViewModel MainViewModel = new();
        public static NotepadViewModel NotepadViewModel = new();
        public static ChatViewModel ChatViewModel = new(MainViewModel);

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = MainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
