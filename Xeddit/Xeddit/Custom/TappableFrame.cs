using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xeddit.Custom
{
    public class TappableFrame : Frame
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TappableFrame));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(TappableFrame));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public event EventHandler<FrameTappedEventArgs> Tapped;

        public void OnTapped(Point location)
        {
            Tapped?.Invoke(this, new FrameTappedEventArgs { Point = location });
            Command?.Execute(CommandParameter);
        }
    }

    public class FrameTappedEventArgs : EventArgs
    {
        public Point Point { get; set; }
    }
}