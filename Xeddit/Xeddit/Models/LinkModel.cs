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
    public class LinkModel : ILinkModel
    {
        private readonly ILinkClient m_linkClient;
        private string m_after;

        public LinkModel(ILinkClient linkClient)
        {
            m_linkClient = linkClient;
        }

        public async Task<List<Link>> GetLinksForSubredditAsync(string subreddit, LinkCategory linkCategory, int count = -1, int limit = -1)
        {
            var queryString = BuildQuery(m_after, before: null, count, limit);
            var pathString = $"/r/{subreddit}/";

            switch (linkCategory)
            {
                case LinkCategory.Hot:
                    pathString += "hot";
                    break;
                case LinkCategory.Top:
                    pathString += "top";
                    break;
            }

            var listingOfLinks = await m_linkClient.GetLinksAsync(pathString, queryString);

            m_after = listingOfLinks.After;

            return listingOfLinks.Children.Select(thingWrapper => thingWrapper.Data as Link).ToList();
        }

        private string BuildQuery(string after = null, string before = null, int count = -1, int limit = -1)
        {
            var query = "?";

            if (after != null) query += $"after={after}";

            if (before != null)
            {
                QueryContainsParameters(ref query);
                query += $"before={before}";
            }

            if (count != -1)
            {
                QueryContainsParameters(ref query);
                query += $"count={count}";
            }

            if (limit != -1)
            {
                QueryContainsParameters(ref query);
                query += $"limit={limit}";
            }

            return query.EndsWith("?") ? null : query;
        }

        private void QueryContainsParameters(ref string query)
        {
            if (query == null) return;
            if (!query.EndsWith("?")) query += "&";
        }
    }

    public interface ILinkModel
    {
        Task<List<Link>> GetLinksForSubredditAsync(string subreddit, LinkCategory linkCategory, int count = -1, int limit = -1);
    }

    public enum LinkCategory
    {
        Hot,
        New,
        Random,
        Rising,
        Top
    }
}
