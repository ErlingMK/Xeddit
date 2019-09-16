using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xeddit.DataModels;
using Xeddit.Services.Http;

namespace Xeddit.Clients
{
    public class ListingClient : IListingClient
    {
        private readonly string m_baseAddress = "https://oauth.reddit.com";
        private readonly IHttpClient client;

        public ListingClient(IHttpFactory httpFactory)
        {
            client = httpFactory.Create();
        }

        public async Task<ListingWrapper> GetListingAsync(string path, string query = null)
        {
            var uri = new Uri(m_baseAddress + path + ".json");
            var json = await client.GetAsync(uri);
            return JsonConvert.DeserializeObject<ListingWrapper>(json);
        }
    }

    public interface IListingClient
    {
        Task<ListingWrapper> GetListingAsync(string path, string query = null);
    }
}
