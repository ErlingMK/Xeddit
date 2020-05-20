using System;
using System.Threading.Tasks;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xeddit.Custom;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;
using Xeddit.Views.Front;
using Xeddit.Views.Front.ViewModel;
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
            InputTransparent = true;
            if (sender is Frame frame)
            {
                var resource = Resources["LinkTemplate"];

                if (!(resource is DataTemplate dataTemplate))return;

                var content = dataTemplate.CreateContent();
                if (!(content is ViewCell viewCell)) return;
                var viewCellView = viewCell.View;
                viewCellView.BindingContext = frame.BindingContext;
                viewCellView.Margin = new Thickness(0);

                var image = (frame.Content as Grid).FindByName<Image>("Image").Width;
                var tappableFrame = viewCellView as TappableFrame;
                tappableFrame.Tapped -= FrameTapped;
                var grid = tappableFrame.Content as Grid;
                grid.ColumnDefinitions[2].Width = image;

                AbsoluteLayout.SetLayoutBounds(viewCellView, new Rectangle(new Point(e.Point.X, e.Point.Y - 30), frame.Bounds.Size));
                var absoluteLayout = this.GetParentOfType<AbsoluteLayout>();
                absoluteLayout.Children.Add(viewCellView);

                var frontPage = this.GetParentOfType<FrontPage>();
                var frontPageBindingContext = frontPage.BindingContext as IFrontViewModel;
                frontPageBindingContext.GoToCommentsCommand.ExecuteAsync(frame.BindingContext as ILinkViewModel);
            }
        }
    }
}