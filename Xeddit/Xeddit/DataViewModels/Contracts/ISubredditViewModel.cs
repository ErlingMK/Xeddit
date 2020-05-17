using System.ComponentModel;

namespace Xeddit.DataViewModels.Contracts
{
    public interface ISubredditViewModel : INotifyPropertyChanged
    {
        int? AccountsActive { get; }
        string Description { get; }
        string DisplayName { get; }
        long Subscribers { get; }
        string Title { get; }
        string Url { get; }

        string DisplayNamePrefixed { get; }
    }
}