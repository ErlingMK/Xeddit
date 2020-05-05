using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xeddit.Clients;
using Xeddit.Clients.Abstractions;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;

namespace Xeddit.Views.Comments
{
    public class CommentPageViewModel : ICommentPageViewModel
    {
        private readonly ICommentsService m_commentsService;

        public CommentPageViewModel(ICommentsService commentsService)
        {
            m_commentsService = commentsService;
        }

        public async Task Initialize(ILinkViewModel link)
        {
            CurrentLink = link;

            await LoadComments();
        }

        public RangeObservableCollection<ICommentViewModel> Comments { get; } = new RangeObservableCollection<ICommentViewModel>(){new CommentViewModel(){Body = "asdasdasd"}};

        public ILinkViewModel CurrentLink { get; private set; }

        private Task LoadComments()
        {
            return Task.CompletedTask;
            //var (item1, comments) = await m_commentsService.GetComments(CurrentLink);
            //Comments.AddRange(comments);
        }
    }
}