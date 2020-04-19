using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.Views.Front.ViewModel
{
    public interface ISubredditViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ILink> Links { get; set; }
        Task Initialize();
        bool IsBusy { get; }
        IAsyncCommand<ILink> GoToCommentsCommand { get; }
    }
}
