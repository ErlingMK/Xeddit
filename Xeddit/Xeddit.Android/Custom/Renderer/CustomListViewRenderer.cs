using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xeddit.Custom;
using Xeddit.Droid.Custom.Renderer;
using ListView = Android.Widget.ListView;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace Xeddit.Droid.Custom.Renderer
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        private CustomListView m_list;

        public CustomListViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement is CustomListView oldListView && Control != null)
            {
                oldListView.StopScroll -= StopScroll;
                oldListView.Scrolled -= SharedListViewOnScrolled;
            }

            if (e.NewElement is CustomListView newListView && Control != null)
            {
                m_list = newListView;
                newListView.StopScroll += StopScroll;
                newListView.Scrolled += SharedListViewOnScrolled;
            }
        }

        private void SharedListViewOnScrolled(object sender, ScrolledEventArgs e)
        {
            m_list.FirstVisibleItemPosition = Control?.FirstVisiblePosition;
            m_list.LastVisibleItemPosition = Control?.LastVisiblePosition;
            if (Control?.LastVisiblePosition == (Control?.Adapter.Count - 1))
            {
                m_list.LoadMoreCommand?.Execute(null);
            }
        }

        private void StopScroll(object sender, EventArgs e)
        {
            Control?.SmoothScrollBy(0, 0);
        }
    }
}