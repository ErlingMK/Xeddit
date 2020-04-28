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
        private SubredditBackView m_subredditBackView;
        private SubredditFrontView m_subredditFrontView;

        public FrontPage(IFrontViewModel frontViewModel)
        {
            BindingContext = m_frontViewModel = frontViewModel;
            m_frontViewModel.PropertyChanged += FrontViewModel_OnPropertyChanged;
            m_subredditBackView = new SubredditBackView { BindingContext = m_frontViewModel.CurrentListing };
            m_subredditFrontView = new SubredditFrontView { BindingContext = m_frontViewModel.CurrentListing };

            InitializeComponent();
        }

        private async void FrontViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!(sender is IFrontViewModel viewModel) || e.PropertyName != nameof(viewModel.CurrentListing)) return;

            switch (viewModel.CurrentListing)
            {
                case ISubredditPageViewModel _:
                    await CommentsBackDrop.FadeTo(0, 150);
                    BackDropContainer.RaiseChild(SubredditBackDrop);
                    await SubredditBackDrop.FadeTo(1, 150);
                    break;
                case ICommentPageViewModel _:
                    await SubredditBackDrop.FadeTo(0, 150);
                    BackDropContainer.RaiseChild(CommentsBackDrop);
                    await CommentsBackDrop.FadeTo(1, 150);
                    break;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (!(m_frontViewModel.CurrentListing is ICommentPageViewModel)) return true;
            m_frontViewModel.CurrentListing = m_frontViewModel.SubredditPageViewModel;
            return true;
        }
    }
}