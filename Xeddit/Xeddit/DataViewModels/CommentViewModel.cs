using System.Collections.Generic;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataViewModels
{
    public class CommentViewModel : ICommentViewModel
    {
        public int? Ups { get; set; }
        public int? Downs { get; set; }
        public bool? Likes { get; set; }
        public long? Created { get; set; }
        public long? CreatedUtc { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public string LinkId { get; set; }
        public string ParentId { get; set; }
        public IList<ListingWrapper> Replies { get; set; }
        public int? Score { get; set; }
        public string Subreddit { get; set; }
        public string SubredditId { get; set; }
    }
}