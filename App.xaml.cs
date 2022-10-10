using NotepadPlusPlusPlus.ViewModel;
using System.Windows;

/* 
 * To publish as single file, use 
 * dotnet publish -c Release -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "./bin/publish"
 */

namespace NotepadPlusPlusPlus
{
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
