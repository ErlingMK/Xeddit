using System.Collections.Generic;
using System.Threading.Tasks;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;

namespace Xeddit.Clients.Abstractions
{
    public interface ICommentsService
    {
        Task<(ILinkViewModel, IList<ICommentViewModel>)> GetComments(ILinkViewModel link);
    }
}