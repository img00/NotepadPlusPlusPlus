using System;
using System.Windows.Controls;


namespace NotepadPlusPlusPlus.View.Extensions
{
    /// <summary>
    /// MenuItem with extended functionality, mainly the ability to hover grey when disabled. This code is a mess, please don't look.
    /// </summary>
    public partial class ExtendedMenuItem : MenuItem
    {
        public ExtendedMenuItem()
        {
            PreviewMouseUp += ExtendedMenuItem_PreviewMouseUp;
        }

        // Stops MouseUp from carrying on when clicking on a disabled MenuItem. MouseUp would cause the menu to close
        // because the button is not really disabled and still detects clicks.
        private void ExtendedMenuItem_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Tag.Equals("Disabled"))
                e.Handled = true;
        }

        private void Command_CanExecuteChanged(object? sender, EventArgs e)
        {
            Tag = Command.CanExecute(null) ? "" : "Disabled";
        }

        // OnApplyTemplate is used not because it makes any sense, but because it's the only method I've found that only executes once
        // and where Command is already loaded. You can't place Command.CanExecuteChanged on the constructor because it will return null.
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Command == null) return;
            Command.CanExecuteChanged += Command_CanExecuteChanged;
        }


        protected override bool IsEnabledCore => true;
    }
}
