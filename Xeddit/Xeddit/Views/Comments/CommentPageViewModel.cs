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

        public ILinkViewModel CurrentLink { get; private set; }

        private async Task LoadComments()
        {
            var comments = await m_commentsService.GetComments(CurrentLink);
        }
    }
}