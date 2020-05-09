using System.Collections.Generic;
using System.Threading.Tasks;
using Xeddit.DataViewModels;

namespace Xeddit.Clients.Abstractions
{
    public interface ILinkService
    {
        Task<IList<ILinkViewModel>> GetLinkListingAsync(string subreddit, bool reset = false);
    }
}