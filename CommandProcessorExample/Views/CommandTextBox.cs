using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandProcessorExample.Views
{
    public class CommandTextBox : TextBox
    {
        public static readonly DependencyProperty LostKeyboardFocusCommandProperty =
            DependencyProperty.Register("LostKeyboardFocusCommand", typeof(ICommand), typeof(CommandTextBox),
                new PropertyMetadata(default(ICommand)));

        public ICommand LostKeyboardFocusCommand
        {
            get => (ICommand)GetValue(LostKeyboardFocusCommandProperty);
            set => SetValue(LostKeyboardFocusCommandProperty, value);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Pressing Enter causes this TextBox to lose focus (causing the command to be executed)
            if (e.Key == Key.Enter)
                Keyboard.ClearFocus();
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);

            LostKeyboardFocusCommand?.Execute(null);
        }
    }

}
