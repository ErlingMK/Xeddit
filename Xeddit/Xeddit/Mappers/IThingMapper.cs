using System.Collections.Generic;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Mappers
{
    public interface IThingMapper
    {
        void Mapper(ref ListingWrapper listingWrapper);
        IList<ILinkViewModel> LinkMapper(List<ThingWrapper> links);
        IList<ISubredditViewModel> SubredditMapper(List<ThingWrapper> subreddits);
        (ILinkViewModel, IList<ICommentViewModel>) LinkWithCommentsMapper(List<ListingWrapper> comments);
        IList<ICommentViewModel> CommentsMapper(List<ThingWrapper> comments);
    }
}