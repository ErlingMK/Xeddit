using System.ComponentModel;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;
using Xeddit.Views.Comments;
using Xeddit.Views.Comments.ViewModel;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Views.Front.ViewModel
{
    public interface IFrontViewModel : INotifyPropertyChanged
    {
        ISubredditPageViewModel SubredditPageViewModel { get; }
        ICommentPageViewModel CommentPageViewModel { get; }
        object CurrentListing { get; set; }
        IAsyncCommand<ILinkViewModel> GoToCommentsCommand { get; }
    }
}