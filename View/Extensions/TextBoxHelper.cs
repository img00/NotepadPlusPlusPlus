using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotepadPlusPlusPlus.View.Extensions
{
    public class TextBoxHelper
    {


        private string _selectedText;
        public string SelectedText
        {
            get 
            {
                return _selectedText;
            }
            set 
            {
                _selectedText = value; 
            }
        }

        //private static void SelectedTextChanged (DependencyObject obj, DependencyPropertyChangedEventArgs e)

        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached("SelectedText",
                    typeof(string), typeof(TextBoxHelper),
                    new PropertyMetadata(null));


    }
}
