using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.Views.Comments;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Views.Front.ViewModel
{
    public class FrontViewModel : IFrontViewModel
    {
        private readonly ICommentsViewModel m_commentsViewModel;
        private readonly ISubredditViewModel m_subredditViewModel;
        private object m_currentListing;

        public FrontViewModel(ISubredditViewModel subredditViewModel, ICommentsViewModel commentsViewModel)
        {
            m_subredditViewModel = subredditViewModel;
            m_commentsViewModel = commentsViewModel;

            CurrentListing = subredditViewModel;

            GoToCommentsCommand = new AsyncCommand<ILink>(async link => await GoToComments(link));
        }

        public IAsyncCommand<ILink> GoToCommentsCommand { get; }

        public object CurrentListing
        {
            get => m_currentListing;
            set => PropertyChanged.RaiseWhenSet(ref m_currentListing, value, this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task GoToComments(ILink link)
        {
            var initialize = m_commentsViewModel.Initialize(link);
            CurrentListing = m_commentsViewModel;
            await initialize;
        }
    }
}