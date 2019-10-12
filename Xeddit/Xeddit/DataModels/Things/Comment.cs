using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things.InterfacesForThings;

namespace Xeddit.DataModels.Things
{
    public interface IComment
    {
        string Author { get; set; }
        string Body { get; set; }
        string LinkId { get; set; }
        string ParentId { get; set; }
        IList<ThingWrapper> Replies { get; set; }
        int Score { get; set; }
        string Subreddit { get; set; }
        string SubredditId { get; set; }
        int Ups { get; set; }
        int Downs { get; set; }
        bool? Likes { get; set; }
        long Created { get; set; }
        long CreatedUtc { get; set; }
        string Kind { get; set; }
        object Data { get; set; } // Can be a Link, Comment etc. THINGS
    }

    /// <summary>
    /// Type prefix: t1
    /// </summary>
    public class Comment : ThingWrapper, IVotable, ICreated, IComment
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public string LinkId { get; set; }
        public string ParentId { get; set; }
        public IList<ThingWrapper> Replies { get; set; }
        public int Score { get; set; }
        public string Subreddit { get; set; }
        public string SubredditId { get; set; }

        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public long Created { get; set; }
        public long CreatedUtc { get; set; }
    }
}
