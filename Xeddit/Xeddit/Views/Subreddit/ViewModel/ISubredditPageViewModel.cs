using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;

namespace Xeddit.Views.Subreddit.ViewModel
{
    public interface ISubredditPageViewModel : INotifyPropertyChanged
    {
        RangeObservableCollection<ILinkViewModel> Links { get; }
        RangeObservableCollection<ISubredditViewModel> Subreddits { get; }
        Task Initialize();
        bool IsBusy { get; }
        IAsyncCommand NextLinksCommand { get; }
        string SubredditSearchString { get; }
        IAsyncCommand NewSubredditCommand { get; }
        string CurrentSubreddit { get; }
    }
}
