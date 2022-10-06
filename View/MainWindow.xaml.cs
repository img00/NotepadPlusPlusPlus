using System;
using System.Windows;
using System.Windows.Media.Imaging;

/* 
 * To publish as single file, use 
 * dotnet publish -c Release -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "./bin/publish"
 */

namespace NotepadPlusPlusPlus
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
