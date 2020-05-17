using System.Collections.Generic;
using System.Threading.Tasks;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;

namespace Xeddit.Clients.Abstractions
{
    public interface ICommentsService
    {
        Task<(ILinkViewModel, IList<ICommentGroup>)> GetComments(ILinkViewModel link);
    }
}