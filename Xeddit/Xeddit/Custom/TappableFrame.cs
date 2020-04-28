using System;
using Xamarin.Forms;

namespace Xeddit.Custom
{
    public class TappableFrame : Frame
    {
        public event EventHandler<FrameTappedEventArgs> Tapped;

        public void OnTapped(Point location)
        {
            Tapped?.Invoke(this, new FrameTappedEventArgs { Point = location });
        }
    }

    public class FrameTappedEventArgs : EventArgs
    {
        public Point Point { get; set; }
    }
}