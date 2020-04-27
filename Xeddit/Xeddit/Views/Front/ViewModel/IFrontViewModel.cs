using System.ComponentModel;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.Views.Front.ViewModel
{
    public interface IFrontViewModel : INotifyPropertyChanged
    {
        object CurrentListing { get; }
        IAsyncCommand<ILink> GoToCommentsCommand { get; }
    }
}