using NotepadPlusPlusPlus.Model;
using NotepadPlusPlusPlus.Model.WindowModels;
using NotepadPlusPlusPlus.ViewModel.Chat;
using NotepadPlusPlusPlus.ViewModel.Commands.Chat;
using NotepadPlusPlusPlus.ViewModel.Commands.Edit;
using NotepadPlusPlusPlus.ViewModel.Commands.File;
using NotepadPlusPlusPlus.ViewModel.Commands.Format;
using NotepadPlusPlusPlus.ViewModel.Commands.HelpMenu;
using NotepadPlusPlusPlus.ViewModel.Commands.ViewMenu;
using NotepadPlusPlusPlus.ViewModel.Notepad;
using System;
using System.Windows.Input;

namespace NotepadPlusPlusPlus.ViewModel.Main
{
    public class MainViewModel : ICloseWindow
    {
        #region Command definitions
        public FileMenuCommands FileCommands { get; } = new FileMenuCommands();
        public EditMenuCommands EditCommands { get; } = new EditMenuCommands();
        public FormatMenuCommands FormatCommands { get; } = new FormatMenuCommands();
        public ViewMenuCommands ViewCommands { get; } = new ViewMenuCommands();
        public HelpMenuCommands HelpCommands { get; } = new HelpMenuCommands();
        public ChatCommands ChatCommands { get; } = new ChatCommands();
        #endregion

        public MainViewModel()
        {
            WindowModel.Title = $"{Document.Name}: Bloc de notas";
            Document.PropertyChanged += (_, e) => DocumentChanged();

            CurrentViewModel = NotepadViewModel;
            CurrentModel = NotepadModel;
            WindowModel.CurrentView = App.NotepadView;
        }

        #region Model definitions
        public TextboxModel CurrentModel { get; set; }

        public WindowModel WindowModel { get; } = new WindowModel();
        public NotepadModel NotepadModel { get; } = new NotepadModel();
        public ChatModel ChatModel { get; } = new ChatModel();
        public DocumentModel Document { get; } = new DocumentModel();
        #endregion


        #region ViewModel definitions
        public object CurrentViewModel { get; set; }
        public NotepadViewModel NotepadViewModel { get; set; } = App.NotepadViewModel;
        public ChatViewModel ChatViewModel { get; set; } = App.ChatViewModel;
        #endregion


        public void DocumentChanged()
        {
            UpdateWindowTitle();
        }

        private void UpdateWindowTitle()
        {
            if (WindowModel.IsChatting)
                WindowModel.Title = $"{ChatModel.Title}: Bloc de notas";
            else
                WindowModel.Title = (Document.Unsaved ? "*" : "")
                                 + Document.Name
                                 + ": Bloc de notas";
        }

        public void SwitchView(bool chat)
        {
            if (chat)
                App.ChatViewModel.SwitchToChatView();
            else
                App.NotepadViewModel.SwitchToNotepadView();


            UpdateWindowTitle();
        }


        public bool CanClose() => ((CommandClose)FileCommands.CmdClose).CanClose();
        /// <summary>
        /// This action is executed only when the Close <c>MenuItem</c> is pressed. This calls the Close command of the window, which
        /// asks <see cref="CanClose"/> above. If the window closing is started by pressing X, this is not called.
        /// </summary>
        public Action? Close { get; set; }

        public ICommand TextBoxChangedCommand { get; } = new TextBoxChangedCommand();
    }

    interface ICloseWindow
    {
        Action? Close { get; set; }
        bool CanClose();
    }
}
