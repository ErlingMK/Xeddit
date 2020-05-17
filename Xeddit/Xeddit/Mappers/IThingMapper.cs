using System.Collections.Generic;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Mappers
{
    public interface IThingMapper
    {
        void Mapper(ref ListingWrapper listingWrapper);
        IList<ILinkViewModel> LinkMapper(List<ThingWrapper> links);
        IList<ISubredditViewModel> SubredditMapper(List<ThingWrapper> subreddits);
        (ILinkViewModel, IList<ICommentGroup>) LinkWithCommentsMapper(List<ListingWrapper> comments);
        IList<ICommentGroup> CommentsMapper(List<ThingWrapper> comments);
    }
}