using System.Threading.Tasks;
using Xeddit.DataModels;

namespace Xeddit.Clients
{
    public interface ILinkService
    {
        Task<Listing> GetLinkListingAsync(string subreddit, bool reset = false);
    }
}