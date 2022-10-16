using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace NotepadPlusPlusPlus.View.Extensions
{
    public class ExtendedTextBox : TextBox
    {
        public event RoutedEventHandler? EditingCommandTriggered;
        public ExtendedTextBox()
        {
            SelectionChanged += ExtendedTextBox_SelectionChanged;

        }

        protected override void OnInitialized(EventArgs e)
        {
            if (CatchEditingCommands)
            {
                CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, HasCut));
                CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, HasPasted));
                CommandBindings.Add(new CommandBinding(EditingCommands.Delete, HasDeleted));
            }
            base.OnInitialized(e);
        }

        private void HasCut(object sender, ExecutedRoutedEventArgs e) => EditingCommandTriggered?.Invoke(sender, e);

        private void HasPasted(object sender, ExecutedRoutedEventArgs e) => EditingCommandTriggered?.Invoke(sender, e);

        private void HasDeleted(object sender, ExecutedRoutedEventArgs e) => EditingCommandTriggered?.Invoke(sender, e);


        private int _lastCaretBeforeSelection;
        private void ExtendedTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!IsEnabled) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Input,
                  new Action(
                     delegate
                     {
                         Focus();
                         Keyboard.Focus(this);
                     }
                  )
            );

            if (SelectionLength == 0) _lastCaretBeforeSelection = CaretIndex;
            TextBoxHelper.SetSelectionStart(this, SelectionStart);
            TextBoxHelper.SetSelectionLength(this, SelectionLength);
            TextBoxHelper.SetSelectedText(this, SelectedText);

            TextBoxHelper.SetCaretIndex(this, CaretIndex);


            int caretPosInSelection = _lastCaretBeforeSelection > CaretIndex ? CaretIndex : CaretIndex + SelectionLength;
            int line = GetLineIndexFromCharacterIndex(caretPosInSelection);
            if (line < 0) return;
            int column = caretPosInSelection - GetCharacterIndexFromLineIndex(line);
            TextBoxHelper.SetLine(this, line);
            TextBoxHelper.SetColumn(this, column);
            
        }



        public bool CatchEditingCommands
        {
            get => (bool)GetValue(CatchEditingCommandsProperty);
            set => SetValue(CatchEditingCommandsProperty, value);
        }

        // Using a DependencyProperty as the backing store for CatchEditingCommands.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CatchEditingCommandsProperty =
            DependencyProperty.Register("CatchEditingCommands", typeof(bool), typeof(ExtendedTextBox), new PropertyMetadata(false));


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

            if (e.OldValue == null && e.NewValue != null)
                tb.SelectionChanged += tb_SelectionChanged;
            else if (e.OldValue != null && e.NewValue == null)
                tb.SelectionChanged -= tb_SelectionChanged;

            if (e.NewValue == null) return;
            string newValue = (string)e.NewValue;

            if (newValue.Equals(tb.SelectedText)) return;
            tb.SelectedText = newValue;
        }

        static void tb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox? tb = sender as TextBox;
            if (tb == null) return;

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


        #region Line
        public static int GetLine(DependencyObject obj) =>
            (int)obj.GetValue(LineProperty);

        public static void SetLine(DependencyObject obj, int value) =>
            obj.SetValue(LineProperty, value);

        public static readonly DependencyProperty LineProperty =
            CreateDependencyProperty("Line", typeof(int), LineChanged);

        private static void LineChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;
            if (e.NewValue == null) return;
            if (tb.SelectionLength > 0) return;
            if (tb.LineCount <= 0) return;

            int caret = tb.GetCharacterIndexFromLineIndex((int)e.NewValue) + GetColumn(tb);

            if (caret == tb.CaretIndex) return;

            tb.CaretIndex = caret;
            SetCaretIndex(tb, caret);
        }
        #endregion


        #region Column
        public static int GetColumn(DependencyObject obj) =>
            (int)obj.GetValue(ColumnProperty);

        public static void SetColumn(DependencyObject obj, int value) =>
            obj.SetValue(ColumnProperty, value);

        public static readonly DependencyProperty ColumnProperty =
            CreateDependencyProperty("Column", typeof(int), ColumnChanged);

        private static void ColumnChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox? tb = obj as TextBox;
            if (tb == null) return;
            if (e.NewValue == null) return;
            if (tb.SelectionLength > 0) return;
            if (tb.LineCount <= 0) return;

            int caret = tb.GetCharacterIndexFromLineIndex(GetLine(tb)) + (GetColumn(tb) + ((int)e.NewValue - GetColumn(tb)));

            if (caret == tb.CaretIndex) return;

            tb.SelectionStart = caret;
            SetCaretIndex(tb, caret);
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
