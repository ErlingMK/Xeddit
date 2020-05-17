using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xeddit.Clients.Abstractions;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;
using Xeddit.Mappers;
using Xeddit.Services.Http;

namespace Xeddit.Clients
{
    public class LinkService : ILinkService
    {
        private readonly IThingMapper m_thingMapper;
        private readonly IHttpClient m_client;
        private string m_after;
        private int? m_count;

        public LinkService(IHttpFactory httpFactory, IThingMapper thingMapper)
        {
            m_thingMapper = thingMapper;
            m_client = httpFactory.Create();
        }

        public async Task<IList<ILinkViewModel>> GetLinkListingAsync(string subreddit, bool reset = false)
        {
            if (reset)
            {
                m_after = string.Empty;
                m_count = 0;
            }

            var json = await m_client.GetAsync(CreatePath(subreddit));
            var listingWrapper = JsonConvert.DeserializeObject<ListingWrapper>(json);

            var linkViewModels = m_thingMapper.LinkMapper(listingWrapper?.Data?.Children);

            m_after = listingWrapper?.Data?.After;
            m_count += listingWrapper?.Data?.Children?.Count;

            return linkViewModels;
        }

        private string CreatePath(string path)
        {
            if (string.IsNullOrEmpty(m_after) && (!m_count.HasValue || m_count.Value == 0))
            {
                return $"/r/{path}/.json?limit=25";
            }
            else
            {
                return $"/r/{path}/.json?after={m_after}&count={m_count.GetValueOrDefault()}&limit=25";
            }
        }
    }
}
