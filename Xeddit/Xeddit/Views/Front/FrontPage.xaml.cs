using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.Views.Comments;
using Xeddit.Views.Front.ViewModel;
using Xeddit.Views.Subreddit;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Views.Front
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrontPage : ContentPage
    {
        private readonly IFrontViewModel m_frontViewModel;

        public FrontPage(IFrontViewModel frontViewModel)
        {
            BindingContext = m_frontViewModel = frontViewModel;
            InitializeComponent();
        }

        private async void BackDropPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is BackDrop backDrop && e.PropertyName == nameof(backDrop.BindingContext))
            {
                if (backDrop.BindingContext is ISubredditViewModel)
                {
                    backDrop.BackLayerContent = new SubredditBackView { BindingContext = m_frontViewModel.CurrentListing };
                    backDrop.FrontLayerContent = new SubredditFrontView { BindingContext = m_frontViewModel.CurrentListing };
                }
                else if (backDrop.BindingContext is ICommentsViewModel)
                {
                    await Task.WhenAll(backDrop.FrontLayer.TranslateTo(0, backDrop.BackLayer.Height, 250, Easing.CubicInOut));
                    await Task.WhenAll(backDrop.FrontLayer.TranslateTo(0, backDrop.FrontLayerOffset, 250, Easing.CubicInOut));

                    backDrop.BackLayerContent = new CommentsBackView { BindingContext = m_frontViewModel.CurrentListing };
                    backDrop.FrontLayerContent = new CommentsFrontView { BindingContext = m_frontViewModel.CurrentListing };
                    
                }
            }
        }
    }
}