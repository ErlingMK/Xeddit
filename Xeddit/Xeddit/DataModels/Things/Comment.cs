using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataModels.Things
{
    /// <summary>
    /// Type prefix: t1
    /// </summary>
    public class Comment : Thing, IComment
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public string LinkId { get; set; }
        public string ParentId { get; set; }
        public object Replies { get; set; }
        public int? Score { get; set; }
        public string Subreddit { get; set; }
        public string SubredditId { get; set; }
        public int? Ups { get; set; }
        public int? Downs { get; set; }
        public bool? Likes { get; set; }
        public long? Created { get; set; }
        public long? CreatedUtc { get; set; }
    }
}
