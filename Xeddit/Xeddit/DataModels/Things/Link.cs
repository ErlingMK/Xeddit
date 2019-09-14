using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things.InterfacesForThings;

namespace Xeddit.DataModels.Things
{
    /// <summary>
    /// Type prefix: t3
    /// </summary>
    public class Link : Thing, IVotable, ICreated
    {
        public string Author { get; private set; }
        public string Domain { get; private set; }
        public bool IsSelf { get; private set; }
        public int NumComments { get; private set; }
        public bool Over18 { get; private set; }
        public int Score { get; private set; }
        public string SelfText { get; private set; }
        public string Subreddit { get; private set; }
        public string SubredditId { get; private set; }
        public string Thumbnail { get; private set; }
        public string Title { get; private set; }
        public string Url { get; private set; }
        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public long Created { get; set; }
        public long CreatedUtc { get; set; }
    }
}
