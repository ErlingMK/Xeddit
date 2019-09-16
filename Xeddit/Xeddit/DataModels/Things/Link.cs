using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xeddit.DataModels.Things.InterfacesForThings;

namespace Xeddit.DataModels.Things
{
    /// <summary>
    /// Type prefix: t3
    /// </summary>
    public class Link : Thing, IVotable, ICreated
    {
        public string Author { get; set; }
        public string Domain { get; set; }
        public bool IsSelf { get; set; }
        public int NumComments { get; set; }
        public bool Over18 { get; set; }
        public int Score { get; set; }
        public string SelfText { get; set; }
        public string Subreddit { get; set; }
        public string SubredditId { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public long Created { get; set; }
        public long CreatedUtc { get; set; }
    }
}
