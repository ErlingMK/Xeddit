using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.Services.Http;

namespace Xeddit.Clients
{
    public class LinkClient : ILinkClient
    {
        private readonly string m_baseAddress = "https://oauth.reddit.com";
        private readonly IHttpClient m_client;

        public LinkClient(IHttpFactory httpFactory)
        {
            m_client = httpFactory.Create();
        }

        public async Task<Listing> GetLinksAsync(string path, string query = null)
        {
            var uri = new Uri(m_baseAddress + path + ".json" + query);
            var json = await m_client.GetAsync(uri);
            var listingWrapper = JsonConvert.DeserializeObject<ListingWrapper>(json);

            foreach (var thingWrapper in listingWrapper.Data.Children)
            {
                if (thingWrapper.Kind != ThingTypes.Link) continue;

                if (thingWrapper.Data is JObject jObject)
                {
                    thingWrapper.Data = jObject.ToObject<Link>();
                }
            } 
            return listingWrapper.Data;
        }
    }

    public interface ILinkClient
    {
        Task<Listing> GetLinksAsync(string path, string query = null);
    }
}
