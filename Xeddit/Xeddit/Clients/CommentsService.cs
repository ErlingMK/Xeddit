using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xeddit.Clients.Abstractions;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;
using Xeddit.Mappers;
using Xeddit.Services.Http;

namespace Xeddit.Clients
{
    public class CommentsService : ICommentsService
    {
        private readonly IThingMapper m_thingMapper;
        private IHttpClient m_httpClient;

        public CommentsService(IHttpFactory httpFactory, IThingMapper thingMapper)
        {
            m_thingMapper = thingMapper;
            m_httpClient = httpFactory.Create();
        }

        public async Task<(ILink, IList<IComment>)> GetComments(ILink link)
        {
            var json = await m_httpClient.GetAsync($"/{link.PrefixedSubreddit}/comments/{link.Id}.json");
            var listings = JsonConvert.DeserializeObject<List<ListingWrapper>>(json);
            
            foreach (var t in listings)
            {
                var listingWrapper = t;
                m_thingMapper.Mapper(ref listingWrapper);
            }

            var updatedLink = listings.First().Data.Children.First().Data as ILink;

            return (updatedLink, new List<IComment>());
        }
    }
}