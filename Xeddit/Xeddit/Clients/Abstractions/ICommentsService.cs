using System.Collections.Generic;
using System.Threading.Tasks;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;

namespace Xeddit.Clients.Abstractions
{
    public interface ICommentsService
    {
        Task<(ILink, IList<IComment>)> GetComments(ILinkViewModel link);
    }
}