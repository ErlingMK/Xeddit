using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            var comments = await m_httpClient.GetAsync($"/{link.PrefixedSubreddit}/comments/{link.Id}");
            var listingWrapper = JsonConvert.DeserializeObject<List<ListingWrapper>>(comments);


            return (new Link(), new List<IComment>());
        }
    }

    public interface ICommentsService
    {
        Task<(ILink, IList<IComment>)> GetComments(ILink link);
    }
}