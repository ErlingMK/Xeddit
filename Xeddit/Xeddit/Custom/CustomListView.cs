using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xeddit.Custom
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(
            nameof(LoadMoreCommand),
            typeof(ICommand),
            typeof(CustomListView));

        public CustomListView() : base(ListViewCachingStrategy.RecycleElement)
        {
        }

        public int? FirstVisibleItemPosition { get; set; }
        public int? LastVisibleItemPosition { get; set; }

        public ICommand LoadMoreCommand
        {
            get => (ICommand)GetValue(LoadMoreCommandProperty);
            set => SetValue(LoadMoreCommandProperty, value);
        }

        public event EventHandler StopScroll;

        public void StopScrolling()
        {
            StopScroll?.Invoke(this, null);
        }
    }
}