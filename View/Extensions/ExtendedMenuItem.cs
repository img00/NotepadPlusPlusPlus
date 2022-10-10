using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NotepadPlusPlusPlus.View.Extensions
{
    public class ExtendedMenuItem : Control
    {
        static ExtendedMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedMenuItem), new FrameworkPropertyMetadata(typeof(ExtendedMenuItem)));
        }

        public override void OnApplyTemplate()
        {
            Button button = new Button();
            MenuItem menuItem = new MenuItem();
            menuItem.Header = "iiiiiiiiii";
            menuItem.Background = Brushes.Red;
            button.Content = button;

            base.OnApplyTemplate();
        }


    }
}
