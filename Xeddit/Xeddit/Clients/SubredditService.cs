using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;
using Xeddit.Mappers;
using Xeddit.Services.Http;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Clients
{
    public class SubredditService : ISubredditService
    {
        private readonly IThingMapper m_thingMapper;
        private IHttpClient m_httpClient;

        public SubredditService(IHttpFactory httpFactory, IThingMapper thingMapper)
        {
            m_httpClient = httpFactory.Create();
            m_thingMapper = thingMapper;
        }
        public async Task<IList<ISubredditViewModel>> GetPopularSubreddits()
        {
            var json = await m_httpClient.GetAsync($"/subreddits/popular/.json");
            var listingWrapper = JsonConvert.DeserializeObject<ListingWrapper>(json);

            var subredditViewModels = m_thingMapper.SubredditMapper(listingWrapper.Data.Children);
            return subredditViewModels;
        }
    }

    public interface ISubredditService
    {
        Task<IList<ISubredditViewModel>> GetPopularSubreddits();
    }
}
