using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Wrappers;
using Xeddit.Mappers;
using Xeddit.Services.Http;

namespace Xeddit.Clients
{
    public class LinkService : ILinkService
    {
        private readonly IThingMapper m_thingMapper;
        private readonly IHttpClient m_client;

        public LinkService(IHttpFactory httpFactory, IThingMapper thingMapper)
        {
            m_thingMapper = thingMapper;
            m_client = httpFactory.Create();
        }

        public async Task<Listing> GetLinkListingAsync(string path, string query = null)
        {
            var json = await m_client.GetAsync($"/r/{path}");
            var listingWrapper = JsonConvert.DeserializeObject<ListingWrapper>(json);
            m_thingMapper.Mapper(ref listingWrapper);

            return listingWrapper.Data;
        }
    }
}
