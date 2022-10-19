using NotepadPlusPlusPlus.View;
using NotepadPlusPlusPlus.ViewModel.Chat;
using NotepadPlusPlusPlus.ViewModel.Main;
using NotepadPlusPlusPlus.ViewModel.Notepad;
using System.IO;
using System.Windows;

/* 
 * To publish as single file, use 
 * dotnet publish -c Release -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "./bin/publish"
 */

namespace NotepadPlusPlusPlus
{
    public partial class App : Application
    {
        public static string? DatabaseLocation = @"C:\Users\Ismael Magro.ismael\Desktop\Database";

        public static NotepadView? NotepadView;
        public static ChatView? ChatView;

        public static MainViewModel? MainViewModel;
        public static NotepadViewModel? NotepadViewModel;
        public static ChatViewModel? ChatViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            StartObjects();

            MainWindow = new MainWindow()
            {
                DataContext = MainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void StartObjects()
        {
            NotepadView = new();
            ChatView = new();

            MainViewModel = new();
            NotepadViewModel = new();
            ChatViewModel = new(MainViewModel);
        }

    }
}
