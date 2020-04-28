using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;

namespace Xeddit.Mappers
{
    public class ThingMapper : IThingMapper
    {
        public void Mapper(ref ListingWrapper listingWrapper)
        {
            foreach (var thingWrapper in listingWrapper.Data.Children)
            {
                if (!(thingWrapper.Data is JObject jObject)) continue;

                switch (thingWrapper.Kind)
                {
                    case ThingTypes.Message:
                        break;
                    case ThingTypes.Comment:
                        thingWrapper.Data = jObject.ToObject<Comment>();
                        if (thingWrapper.Data is IComment comment && comment.Replies is JObject repliesAsJObject &&
                            repliesAsJObject.ContainsKey("kind")) comment.Replies = repliesAsJObject.ToObject<ListingWrapper>();
                        break;
                    case ThingTypes.Link:
                        thingWrapper.Data = jObject.ToObject<Link>();
                        break;
                    case ThingTypes.Account:
                        break;
                    case ThingTypes.More:
                        break;
                }
            }
        }

        public IList<ILinkViewModel> LinkMapper(IList<ThingWrapper> links)
        {
            var linkViewModels = new List<ILinkViewModel>();
            foreach (var thingWrapper in links)
                if (thingWrapper.Data is JObject jObject && thingWrapper.Kind == ThingTypes.Link)
                {
                    thingWrapper.Data = jObject.ToObject<Link>();
                    if (thingWrapper.Data is ILink link)
                        linkViewModels.Add(
                            new LinkViewModel(
                                link.Id,
                                link.Name,
                                link.Ups,
                                link.Downs,
                                link.Likes,
                                link.Created,
                                link.CreatedUtc,
                                link.Author,
                                link.Domain,
                                link.IsSelf,
                                link.NumComments,
                                link.Over18,
                                link.Score,
                                link.SelfText,
                                link.PrefixedSubreddit,
                                link.Subreddit,
                                link.SubredditId,
                                link.Thumbnail,
                                link.Title,
                                link.Url,
                                link.Permalink,
                                link.IsExpanded,
                                link.HasThumbnail));
                }

            return linkViewModels;
        }

        public IList<ISubredditViewModel> SubredditMapper(IList<ThingWrapper> subreddits)
        {
            var subredditViewModels = new List<ISubredditViewModel>();
            foreach (var thingWrapper in subreddits)
                if (thingWrapper.Data is JObject jObject && thingWrapper.Kind == ThingTypes.Subreddit)
                {
                    thingWrapper.Data = jObject.ToObject<Subreddit>();
                    if (thingWrapper.Data is Subreddit subreddit)
                        subredditViewModels.Add(
                            new SubredditViewModel(
                                subreddit.AccountsActive,
                                subreddit.Description,
                                subreddit.DisplayName,
                                subreddit.Subscribers,
                                subreddit.Title,
                                subreddit.Url,
                                subreddit.DisplayNamePrefixed));
                }

            return subredditViewModels;
        }
    }
}