using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using DIPS.Xamarin.UI.Extensions;
using Xeddit.Clients.Abstractions;
using Xeddit.DataViewModels;

namespace Xeddit.Views.Comments.ViewModel
{
    public class CommentPageViewModel : ICommentPageViewModel
    {
        private readonly ICommentsService m_commentsService;
        private bool m_isBusy;

        public CommentPageViewModel(ICommentsService commentsService)
        {
            m_commentsService = commentsService;
        }

        public async Task Initialize(ILinkViewModel link)
        {
            CurrentLink = link;
            Comments.Clear();

            IsBusy = true;
            await LoadComments();
            IsBusy = false;
        }

        public RangeObservableCollection<ICommentViewModel> Comments { get; } = new RangeObservableCollection<ICommentViewModel>();

        public bool IsBusy
        {
            get => m_isBusy;
            set => PropertyChanged.RaiseWhenSet(ref m_isBusy, value);
        }

        public ILinkViewModel CurrentLink { get; private set; }

        private async Task LoadComments()
        {
            var (item1, comments) = await m_commentsService.GetComments(CurrentLink);
            Comments.AddRange(comments);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}