using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;

namespace Xeddit.Views.Comments.ViewModel
{
    public interface ICommentPageViewModel : INotifyPropertyChanged
    {
        ILinkViewModel CurrentLink { get; }
        Task Initialize(ILinkViewModel link);
        RangeObservableCollection<ICommentGroup> Comments { get; }
        bool IsBusy { get; }
    }
}