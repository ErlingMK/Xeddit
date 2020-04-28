using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xeddit.Custom;
using Xeddit.Droid.Custom;
using FrameRenderer = Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer;

[assembly: ExportRenderer(typeof(TappableFrame), typeof(CustomFrame))]
namespace Xeddit.Droid.Custom
{
    class CustomFrame : FrameRenderer
    {
        private readonly Context m_context;

        private TappableFrameListener m_tappableFrameListener;
        private GestureDetector m_gestureDetector;

        public CustomFrame(Context context) : base(context)
        {
            m_context = context;
            m_tappableFrameListener = new TappableFrameListener();
            m_gestureDetector = new GestureDetector(context, m_tappableFrameListener);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
            }

            if (e.NewElement != null)
            {
                GenericMotion += OnGenericMotion;
                Touch += OnTouch;
                m_tappableFrameListener.SingleTap += OnSingleTap;
            }
        }

        private void OnTouch(object sender, TouchEventArgs e)
        {
            m_gestureDetector.OnTouchEvent(e.Event);
        }

        private void OnGenericMotion(object sender, GenericMotionEventArgs e)
        {
            m_gestureDetector.OnGenericMotionEvent(e.Event);
        }

        private void OnSingleTap(object sender, MotionEvent e)
        {
            var ints = new int[2];
            Control?.GetLocationOnScreen(ints);
            var displayMetricsDensity = m_context.Resources.DisplayMetrics.Density;
            var deviceIndepedentPoint = new Point(ints[0] / displayMetricsDensity,ints[1] / displayMetricsDensity);
            (Element as TappableFrame)?.OnTapped(deviceIndepedentPoint);
        }
    }

    public class TappableFrameListener : GestureDetector.SimpleOnGestureListener
    {
        public event EventHandler<MotionEvent> SingleTap;

        public override bool OnSingleTapUp(MotionEvent e)
        {
            SingleTap?.Invoke(this, e);
            return base.OnSingleTapUp(e);
        }
    }
}