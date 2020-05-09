using System.Collections.Generic;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataViewModels
{
    public class CommentViewModel : ICommentViewModel
    {
        public CommentViewModel(int? ups, int? downs, bool? likes, long? created, long? createdUtc, string author, string body, string linkId, string parentId, List<ICommentViewModel> replies, int? score, string subreddit, string subredditId)
        {
            Ups = ups;
            Downs = downs;
            Likes = likes;
            Created = created;
            CreatedUtc = createdUtc;
            Author = author;
            Body = body;
            LinkId = linkId;
            ParentId = parentId;
            Replies = replies;
            Score = score;
            Subreddit = subreddit;
            SubredditId = subredditId;
        }

        public int? Ups { get; }
        public int? Downs { get; }
        public bool? Likes { get; }
        public long? Created { get; }
        public long? CreatedUtc { get; }
        public string Author { get; }
        public string Body { get; }
        public string LinkId { get; }
        public string ParentId { get; }
        public List<ICommentViewModel> Replies { get; }
        public int? Score { get; }
        public string Subreddit { get; }
        public string SubredditId { get; }
    }
}