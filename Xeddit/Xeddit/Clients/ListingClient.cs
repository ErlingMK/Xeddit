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
        private readonly IHttpClient client;

        public ListingClient(IHttpFactory httpFactory)
        {
            client = httpFactory.Create();
        }

        public async Task<ListingWrapper> GetListingAsync(Uri uri)
        {
            var json = await client.GetAsync(uri);
            return JsonConvert.DeserializeObject<ListingWrapper>(json);
        }
    }

    public interface IListingClient
    {
        Task<ListingWrapper> GetListingAsync(Uri uri);
    }
}
