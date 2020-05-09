using System.Collections.Generic;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataViewModels
{
    public interface ICommentViewModel
    {
        int? Ups { get; }
        int? Downs { get; }
        bool? Likes { get; }
        long? Created { get; }
        long? CreatedUtc { get; }
        string Author { get; }
        string Body { get; }
        string LinkId { get; }
        string ParentId { get; }
        List<ICommentViewModel> Replies { get; }
        int? Score { get;  }
        string Subreddit { get;}
        string SubredditId { get; }
    }
}