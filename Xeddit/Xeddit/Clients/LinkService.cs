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
        private string m_after;
        private int m_count;

        public LinkService(IHttpFactory httpFactory, IThingMapper thingMapper)
        {
            m_thingMapper = thingMapper;
            m_client = httpFactory.Create();
        }

        public async Task<Listing> GetLinkListingAsync(string subreddit, bool reset = false)
        {
            if (reset)
            {
                m_after = string.Empty;
                m_count = 0;
            }

            var json = await m_client.GetAsync(CreatePath(subreddit));
            var listingWrapper = JsonConvert.DeserializeObject<ListingWrapper>(json);
            m_thingMapper.Mapper(ref listingWrapper);

            m_after = listingWrapper.Data.After;
            m_count += listingWrapper.Data.Children.Count;

            return listingWrapper.Data;
        }

        private string CreatePath(string path)
        {
            if (string.IsNullOrEmpty(m_after) && m_count == 0)
            {
                return $"/r/{path}/.json?limit=25";
            }
            else
            {
                return $"/r/{path}/.json?after={m_after}&count={m_count}&limit=25";
            }
        }
    }
}
