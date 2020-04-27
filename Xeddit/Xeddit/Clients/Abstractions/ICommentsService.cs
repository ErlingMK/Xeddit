using System.Collections.Generic;
using System.Threading.Tasks;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.Clients.Abstractions
{
    public interface ICommentsService
    {
        Task<(ILink, IList<IComment>)> GetComments(ILink link);
    }
}