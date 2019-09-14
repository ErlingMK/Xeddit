using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xeddit.Clients;
using Xeddit.DataModels.Things;

namespace Xeddit.Models
{
    public class LinkModel : ILinkModel
    {
        private readonly IListingClient m_listingClient;

        public LinkModel(IListingClient listingClient)
        {
            m_listingClient = listingClient;
        }

        public Task<IList<Link>> GetLinksForSubredditAsync(Subreddit subreddit, PostCategories postCategory)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILinkModel
    {
        Task<IList<Link>> GetLinksForSubredditAsync(Subreddit subreddit, PostCategories postCategory);
    }

    public enum PostCategories
    {
        Hot,
        New,
        Random,
        Rising,
        Top
    }
}
