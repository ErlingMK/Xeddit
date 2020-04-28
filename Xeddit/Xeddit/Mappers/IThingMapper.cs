using System.Collections.Generic;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Mappers
{
    public interface IThingMapper
    {
        void Mapper(ref ListingWrapper listingWrapper);
        IList<ILinkViewModel> LinkMapper(IList<ThingWrapper> links);
        IList<ISubredditViewModel> SubredditMapper(IList<ThingWrapper> subreddits);
    }
}