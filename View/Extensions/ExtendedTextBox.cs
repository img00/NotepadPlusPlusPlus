using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NotepadPlusPlusPlus.View.Extensions
{
    public class ExtendedTextBox : TextBox
    {
        public ExtendedTextBox()
        {
            SelectionChanged += ExtendedTextBox_SelectionChanged;
        }

        private void ExtendedTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBoxHelper.SetSelectedText(this, SelectedText);
            TextBoxHelper.SetSelectionStart(this, SelectionStart);
            TextBoxHelper.SetSelectionLength(this, SelectionLength);
            TextBoxHelper.SetCaretIndex(this, CaretIndex);
        }
    }

    public class TextBoxHelper : DependencyObject
    {
        #region SelectedText
        public static string GetSelectedText(DependencyObject obj) =>
            (string)obj.GetValue(SelectedTextProperty);

        public static void SetSelectedText(DependencyObject obj, string value) =>
            obj.SetValue(SelectedTextProperty, value);

        public static readonly DependencyProperty SelectedTextProperty =
            CreateDependencyProperty("SelectedText", typeof(string), SelectedTextChanged);

        private static void SelectedTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;

            if (e.NewValue == null) return;
            string newValue = (string) e.NewValue;
            
            if (newValue.Equals(tb.SelectedText)) return;

            tb.SelectedText = newValue;
            SetSelectedText(tb, tb.SelectedText);
        }
        #endregion


        #region SelectionStart
        public static int GetSelectionStart(DependencyObject obj) =>
            (int)obj.GetValue(SelectionStartProperty);

        public static void SetSelectionStart(DependencyObject obj, int value) =>
            obj.SetValue(SelectionStartProperty, value);

        public static readonly DependencyProperty SelectionStartProperty =
            CreateDependencyProperty("SelectionStart", typeof(int), SelectionStartChanged);

        private static void SelectionStartChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;

            if (e.NewValue == null) return;
            int newValue = (int)e.NewValue;

            if (newValue.Equals(tb.SelectionStart)) return;

            tb.SelectionStart = newValue;
            SetSelectionStart(tb, tb.SelectionStart);
        }
        #endregion


        #region SelectionLength
        public static int GetSelectionLength(DependencyObject obj) =>
            (int)obj.GetValue(SelectionLengthProperty);

        public static void SetSelectionLength(DependencyObject obj, int value) =>
            obj.SetValue(SelectionLengthProperty, value);

        public static readonly DependencyProperty SelectionLengthProperty =
            CreateDependencyProperty("SelectionLength", typeof(int), SelectionLengthChanged);

        private static void SelectionLengthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;

            if (e.NewValue == null) return;
            int newValue = (int)e.NewValue;

            if (newValue.Equals(tb.SelectionLength)) return;

            SetSelectionLength(tb, tb.SelectionLength);
            tb.SelectionLength = newValue;
        }
        #endregion


        #region CaretIndex
        public static int GetCaretIndex(DependencyObject obj) =>
            (int)obj.GetValue(CaretIndexProperty);

        public static void SetCaretIndex(DependencyObject obj, int value) =>
            obj.SetValue(CaretIndexProperty, value);

        public static readonly DependencyProperty CaretIndexProperty =
            CreateDependencyProperty("CaretIndex", typeof(int), CaretIndexChanged);

        private static void CaretIndexChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;

            if (e.NewValue == null) return;
            int newValue = (int)e.NewValue;

            if (newValue.Equals(tb.CaretIndex)) return;

            SetCaretIndex(tb, tb.CaretIndex);
            tb.CaretIndex = newValue;
        }
        #endregion


        #region Helper for creating dependency
        private static DependencyProperty CreateDependencyProperty(string name, Type propertyType, PropertyChangedCallback propertyChangedCallback)
        {
            return DependencyProperty.RegisterAttached(name, propertyType, typeof(TextBoxHelper),
                new FrameworkPropertyMetadata(propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, propertyChangedCallback));
        }
        #endregion
    }
}
