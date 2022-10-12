using System.Windows.Input;

namespace NotepadPlusPlusPlus.View.Extensions
{
    public class MouseWheelGesture : MouseGesture
    {

        public MouseWheelGesture() : base(MouseAction.WheelClick) { }

        public MouseWheelGesture(ModifierKeys modifiers) : base(MouseAction.WheelClick, modifiers) { }

        public WheelDirection Direction { get; set; }
        public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
        {
            return base.Matches(targetElement, inputEventArgs)
                    && inputEventArgs is MouseWheelEventArgs args
                    && Direction switch
                    {
                        WheelDirection.None => args.Delta == 0,
                        WheelDirection.Up => args.Delta > 0,
                        WheelDirection.Down => args.Delta < 0,
                        _ => false,
                    };
        }


        public static MouseWheelGesture CtrlDown => new(ModifierKeys.Control) { Direction = WheelDirection.Down };
        public static MouseWheelGesture CtrlUp => new(ModifierKeys.Control) { Direction = WheelDirection.Up };

    }

    public enum WheelDirection { None, Up, Down }
}
