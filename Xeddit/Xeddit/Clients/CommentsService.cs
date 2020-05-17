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
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;
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

        public async Task<(ILinkViewModel, IList<ICommentGroup>)> GetComments(ILinkViewModel link)
        {
            var json = await m_httpClient.GetAsync($"/{link.PrefixedSubreddit}/comments/{link.Id}.json");
            var listings = JsonConvert.DeserializeObject<List<ListingWrapper>>(json);

            var (linkViewModel, commentViewModels) = m_thingMapper.LinkWithCommentsMapper(listings);

            return (linkViewModel, commentViewModels);
        }
    }
}