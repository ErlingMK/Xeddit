using System.Threading.Tasks;
using Xeddit.Clients;
using Xeddit.Clients.Abstractions;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.Views.Comments
{
    public class CommentsViewModel : ICommentsViewModel
    {
        private readonly ICommentsService m_commentsService;

        public CommentsViewModel(ICommentsService commentsService)
        {
            m_commentsService = commentsService;
        }

        public async Task Initialize(ILink link)
        {
            CurrentLink = link;

            await LoadComments();
        }

        public ILink CurrentLink { get; private set; }

        private async Task LoadComments()
        {
            var comments = await m_commentsService.GetComments(CurrentLink);
        }
    }

    public interface ICommentsViewModel
    {
        ILink CurrentLink { get; }
        Task Initialize(ILink link);
    }
}