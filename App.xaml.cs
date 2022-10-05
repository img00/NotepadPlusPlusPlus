using NotepadPlusPlusPlus.ViewModel;
using System.Windows;

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
