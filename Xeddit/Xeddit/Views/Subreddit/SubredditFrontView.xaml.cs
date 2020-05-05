using System;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xeddit.Custom;
using Xeddit.DataViewModels;
using Xeddit.Views.Subreddit.ViewModel;
using ViewCell = Xamarin.Forms.ViewCell;
using VisualElement = Xamarin.Forms.VisualElement;

namespace Xeddit.Views.Subreddit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubredditFrontView : ContentView
    {
        public SubredditFrontView()
        {
            InitializeComponent();
        }

        private void FrameTapped(object sender, FrameTappedEventArgs e)
        {
            if (sender is Frame frame && BindingContext is ISubredditPageViewModel viewModel)
            {
                var resource = Resources["LinkTemplate"];

                if (!(resource is DataTemplate dataTemplate))return;

                var content = dataTemplate.CreateContent();
                if (!(content is ViewCell viewCell)) return;
                var viewCellView = viewCell.View;
                viewCellView.BindingContext = frame.BindingContext;
                viewCellView.Margin = new Thickness(0);

                AbsoluteLayout.SetLayoutBounds(viewCellView, new Rectangle(new Point(e.Point.X, e.Point.Y - 30), frame.Bounds.Size));
                var absoluteLayout = this.GetParentOfType<AbsoluteLayout>();
                absoluteLayout.Children.Add(viewCellView);
                //customListView.FadeTo(0);
            }
        }
    }
}