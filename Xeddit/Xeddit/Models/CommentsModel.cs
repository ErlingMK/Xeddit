using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeddit.Clients;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;

namespace Xeddit.Models
{
    public interface ICommentsModel
    {
        Task<IList<Comment>> GetCommentsForPostAsync(string permalink);
    }

    public class CommentsModel : ICommentsModel
    {
        private readonly ICommentClient m_commentClient;

        public CommentsModel(ICommentClient commentClient)
        {
            m_commentClient = commentClient;
        }

        public async Task<IList<Comment>> GetCommentsForPostAsync(string permalink)
        {
            var comments = await m_commentClient.GetCommentsAsync(permalink);

            return comments;
        }
    }
}
