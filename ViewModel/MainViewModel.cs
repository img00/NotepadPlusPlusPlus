using NotepadPlusPlusPlus.Model;
using NotepadPlusPlusPlus.ViewModel.Commands.Edit;
using NotepadPlusPlusPlus.ViewModel.Commands.File;
using NotepadPlusPlusPlus.ViewModel.Commands.Format;
using NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel
{
    public class MainViewModel : ObservableObject, ICloseWindow
    {
        public FileMenuCommands FileCommands { get; }
        public EditMenuCommands EditCommands { get; }
        public FormatMenuCommands FormatCommands { get; }
        public ViewMenuCommands ViewCommands { get; }

        public MainViewModel()
        {
            MainWindow.Title = $"{Document.Name}: Bloc de notas";
            Document.PropertyChanged += (_, e) => DocumentChanged();

            FileCommands = new FileMenuCommands(this);
            EditCommands = new EditMenuCommands(this);
            FormatCommands = new FormatMenuCommands(this);
            ViewCommands = new ViewMenuCommands(this);

            TextBoxChangedCommand = new TextBoxChangedCommand(this);

            MainWindow.SelectedText = "AAAAAAA";
            string a = MainWindow.SelectedText;
        }

        public MainWindowModel MainWindow { get; } = new MainWindowModel();
        public DocumentModel Document { get; } = new DocumentModel();
        private void DocumentChanged()
        {
            MainWindow.Title = (Document.Unsaved ? "*" : "")
                             + Document.Name
                             + ": Bloc de notas";
        }


        public bool CanClose() => ((CommandClose)FileCommands.CmdClose).CanClose();
        /// <summary>
        /// This action is executed only when the Close <c>MenuItem</c> is pressed. This calls the Close command of the window, which
        /// asks <see cref="CanClose"/> above. If the window closing is started by pressing X, this is not called.
        /// </summary>
        public Action? Close { get; set; }

        public ICommand TextBoxChangedCommand { get; }
    }

    interface ICloseWindow
    {
        Action? Close { get; set; }
        bool CanClose();
    }





    // TEST: This breaks MVVM, so it probably shouldn't be used. Instead, create a helper for textbox to be able to bind selection
    /*
    public class TextBoxSelectionChangedCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter is RoutedEventArgs re && re.Source is TextBox tb)
            {
                if (tb.SelectionStart != 10)
                    tb.SelectionStart = 10;
            }
        }
    }*/
}
