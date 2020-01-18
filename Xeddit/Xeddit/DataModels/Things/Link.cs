using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;
using Xeddit.DataModels.Things.InterfacesForThings;

namespace Xeddit.DataModels.Things
{
    public interface ILink
    {
        string Author { get; set; }
        string Domain { get; set; }
        bool IsSelf { get; set; }
        int NumComments { get; set; }
        bool Over18 { get; set; }
        int Score { get; set; }
        string SelfText { get; set; }
        string Subreddit { get; set; }
        string SubredditId { get; set; }
        string Thumbnail { get; set; }
        ImageSource ThumbnailAsUri { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        int Ups { get; set; }
        int Downs { get; set; }
        bool? Likes { get; set; }
        long Created { get; set; }
        long CreatedUtc { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        string Permalink { get; set; }
    }

    /// <summary>
    /// Type prefix: t3
    /// </summary>
    public class Link : Thing, IVotable, ICreated, ILink
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
        public ImageSource ThumbnailAsUri { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public long Created { get; set; }
        public long CreatedUtc { get; set; }
        public string Permalink { get; set; }
    }
}
