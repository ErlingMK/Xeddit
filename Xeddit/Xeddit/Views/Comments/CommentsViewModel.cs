using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xeddit.Clients;
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

        public ILink CurrentLink { get; set; }

        public async Task LoadComments(ILink link)
        {
            CurrentLink = link;

            var comments = await m_commentsService.GetComments(link);
        }
    }

    public interface ICommentsViewModel
    {
        ILink CurrentLink { get; }
        Task LoadComments(ILink link);
    }
}
