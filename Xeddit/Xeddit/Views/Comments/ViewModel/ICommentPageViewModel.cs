using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xeddit.DataViewModels;

namespace Xeddit.Views.Comments.ViewModel
{
    public interface ICommentPageViewModel : INotifyPropertyChanged
    {
        ILinkViewModel CurrentLink { get; }
        Task Initialize(ILinkViewModel link);
        RangeObservableCollection<ICommentViewModel> Comments { get; }
        bool IsBusy { get; }
    }
}