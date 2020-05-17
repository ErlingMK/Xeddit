using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;

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
                            repliesAsJObject.ContainsKey("kind"))
                            comment.Replies = repliesAsJObject.ToObject<ListingWrapper>();
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

        public (ILinkViewModel, IList<ICommentGroup>) LinkWithCommentsMapper(List<ListingWrapper> comments)
        {
            var link = LinkMapper(comments.First().Data.Children);
            var commentViewModels = CommentsMapper(comments.Last().Data.Children);
            return (link.Single(), commentViewModels);
        }

        public IList<ICommentGroup> CommentsMapper(List<ThingWrapper> comments)
        {
            var commentViewModels = new List<ICommentGroup>();
            foreach (var thingWrapper in comments)
                if (thingWrapper.Data is JObject jObject)
                    switch (thingWrapper.Kind)
                    {
                        case ThingTypes.Comment:
                            thingWrapper.Data = jObject.ToObject<Comment>();
                            CreateCommentViewModel(thingWrapper.Data, ref commentViewModels);
                            break;
                        case ThingTypes.More:
                            thingWrapper.Data = jObject.ToObject<More>();
                            CreateMoreCommentViewModel(thingWrapper.Data, ref commentViewModels);
                            break;
                    }

            return commentViewModels;
        }

        public IList<ILinkViewModel> LinkMapper(List<ThingWrapper> links)
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

        public IList<ISubredditViewModel> SubredditMapper(List<ThingWrapper> subreddits)
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

        private void CreateMoreCommentViewModel(object moreCommentsModel, ref List<ICommentGroup> commentViewModels)
        {
            if (!(moreCommentsModel is More more)) return;

            commentViewModels.Add(new MoreViewModel(more.Count, more.ParentId, more.Depth, more.Children, more.Id, more.Name));
        }

        private void CreateCommentViewModel(object commentModel, ref List<ICommentGroup> commentViewModels)
        {
            if (!(commentModel is IComment comment)) return;

            var replies = new List<ICommentGroup>();
            if (comment.Replies is JObject repliesAsJObject && repliesAsJObject.ContainsKey("kind"))
                replies =
                    CommentsMapper(repliesAsJObject.ToObject<ListingWrapper>().Data
                        .Children) as List<ICommentGroup>;

            commentViewModels.Add(
                new CommentViewModel(comment.Ups, comment.Downs, comment.Likes,
                    comment.Created, comment.CreatedUtc, comment.Author, comment.Body, comment.LinkId,
                    comment.ParentId, replies, comment.Score, comment.Subreddit,
                    comment.SubredditId));
        }
    }
}