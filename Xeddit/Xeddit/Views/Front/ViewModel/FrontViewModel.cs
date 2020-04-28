using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;
using Xeddit.Views.Comments;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Views.Front.ViewModel
{
    public class FrontViewModel : IFrontViewModel
    {
        private readonly ICommentPageViewModel m_commentPageViewModel;
        private readonly ISubredditPageViewModel m_subredditPageViewModel;
        private object m_currentListing;

        public FrontViewModel(ISubredditPageViewModel subredditPageViewModel, ICommentPageViewModel commentPageViewModel)
        {
            SubredditPageViewModel = subredditPageViewModel;
            CommentPageViewModel = commentPageViewModel;

            CurrentListing = subredditPageViewModel;

            GoToCommentsCommand = new AsyncCommand<ILinkViewModel>(GoToComments);
        }

        public IAsyncCommand<ILinkViewModel> GoToCommentsCommand { get; }

        public ISubredditPageViewModel SubredditPageViewModel { get; }
        public ICommentPageViewModel CommentPageViewModel { get; }


        public object CurrentListing
        {
            get => m_currentListing;
            set => PropertyChanged.RaiseWhenSet(ref m_currentListing, value, this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task GoToComments(ILinkViewModel link)
        {
            //var initialize = m_commentPageViewModel.Initialize(link);
            CurrentListing = CommentPageViewModel;
            //await initialize;
        }
    }
}