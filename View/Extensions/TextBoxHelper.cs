using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NotepadPlusPlusPlus.View.Extensions
{
    public class TextBoxHelper : DependencyObject
    {
        public static string GetSelectedText(DependencyObject obj) => 
            (string)obj.GetValue(SelectedTextProperty);

        public static void SetSelectedText(DependencyObject obj, string value) => 
            obj.SetValue(SelectedTextProperty, value);

        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached(
                name: "SelectedText",
                propertyType: typeof(string),
                ownerType: typeof(TextBoxHelper),
                defaultMetadata: new FrameworkPropertyMetadata(null, SelectedTextChanged));

        private static void SelectedTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;

            if (e.OldValue == null && e.NewValue != null)
                tb.SelectionChanged += tb_SelectionChanged;
            else if (e.OldValue != null && e.NewValue == null)
                tb.SelectionChanged -= tb_SelectionChanged;

            string? newValue = e.NewValue as string;

            if (newValue != null && newValue != tb.SelectedText)
                tb.SelectedText = newValue as string;
        }

        static void tb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox? tb = sender as TextBox;

            if (tb == null) return;
            SetSelectedText(tb, tb.SelectedText);
        }
    }
}
