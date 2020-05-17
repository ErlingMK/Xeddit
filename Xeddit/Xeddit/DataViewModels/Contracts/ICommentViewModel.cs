using System.Collections.Generic;

namespace Xeddit.DataViewModels.Contracts
{
    public interface ICommentViewModel : ICommentGroup
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
        List<ICommentGroup> Replies { get; }
        int? Score { get;  }
        string Subreddit { get;}
        string SubredditId { get; }
    }
}