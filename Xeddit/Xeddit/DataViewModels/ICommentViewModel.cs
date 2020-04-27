using System.Collections.Generic;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataViewModels
{
    public interface ICommentViewModel
    {
        int? Ups { get; set; }
        int? Downs { get; set; }
        bool? Likes { get; set; }
        long? Created { get; set; }
        long? CreatedUtc { get; set; }
        string Author { get; set; }
        string Body { get; set; }
        string LinkId { get; set; }
        string ParentId { get; set; }
        IList<ListingWrapper> Replies { get; set; }
        int? Score { get; set; }
        string Subreddit { get; set; }
        string SubredditId { get; set; }
    }
}