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
                var frameBindingContext = frame.BindingContext as ILinkViewModel;
                //viewModel.Links.Remove(frameBindingContext);

                var resource = Resources["LinkTemplate"];

                var dataTemplate = resource as DataTemplate;

                var content = dataTemplate.CreateContent();
                var viewCell = content as ViewCell;
                var viewCellView = viewCell.View;
                viewCellView.BindingContext = frameBindingContext;
                viewCellView.Margin = new Thickness(0);

                AbsoluteLayout.SetLayoutBounds(viewCellView, new Rectangle(new Point(e.Point.X, e.Point.Y - 81), frame.Bounds.Size));

                absoluteLayout.Children.Add(viewCellView);
                //viewCellView.TranslationY = 200;
                customListView.FadeTo(0);
            }
        }
    }
}