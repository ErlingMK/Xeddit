using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.Services.Http;

namespace Xeddit.Clients
{
    public interface ICommentClient
    {
        Task<List<Comment>> GetCommentsAsync(string permalink);
    }

    public class CommentClient : ICommentClient
    {
        private readonly string m_baseAddress = "https://oauth.reddit.com";
        private readonly IHttpClient m_client;

        public CommentClient(IHttpFactory httpFactory)
        {
            m_client = httpFactory.Create();
        }

        public async Task<List<Comment>> GetCommentsAsync(string permalink)
        {
            var uri = new Uri(m_baseAddress + permalink + ".json");
            var json = await m_client.GetAsync(uri);
            var listingWrappers = JsonConvert.DeserializeObject<List<ListingWrapper>>(json);

            var listings = new List<Listing>();

            foreach (var listingWrapper in listingWrappers)
            {
                listings.Add(ListingParser.ParseThings(listingWrapper));
            }

            var commentListing = listings[1];

            var comments = commentListing.Children.Select(thingwrapper => thingwrapper.Data as Comment).ToList();

            return comments;
        }
    }
}
