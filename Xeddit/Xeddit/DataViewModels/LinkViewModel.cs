using System.ComponentModel;
using Xeddit.DataViewModels.Contracts;

namespace Xeddit.DataViewModels
{
    public class LinkViewModel : ILinkViewModel
    {
        public LinkViewModel(string id, string name, int? ups, int? downs, bool? likes, long? created, long? createdUtc, string author, string domain, bool isSelf, int numComments, bool over18, int score, string selfText, string prefixedSubreddit, string subreddit, string subredditId, string thumbnail, string title, string url, string permalink, bool isExpanded, bool hasThumbnail)
        {
            Id = id;
            Name = name;
            Ups = ups;
            Downs = downs;
            Likes = likes;
            Created = created;
            CreatedUtc = createdUtc;
            Author = author;
            Domain = domain;
            IsSelf = isSelf;
            NumComments = numComments;
            Over18 = over18;
            Score = score;
            SelfText = selfText;
            PrefixedSubreddit = prefixedSubreddit;
            Subreddit = subreddit;
            SubredditId = subredditId;
            Thumbnail = thumbnail;
            Title = title;
            Url = url;
            Permalink = permalink;
            IsExpanded = isExpanded;
            HasThumbnail = hasThumbnail;
        }
        public string Id { get; }
        public string Name { get; }
        public int? Ups { get; }
        public int? Downs { get; }
        public bool? Likes { get; }
        public long? Created { get; }
        public long? CreatedUtc { get; }
        public string Author { get; }
        public string Domain { get; }
        public bool IsSelf { get; }
        public int NumComments { get; }
        public bool Over18 { get; }
        public int Score { get; }
        public string SelfText { get; }
        public string PrefixedSubreddit { get; }
        public string Subreddit { get; }
        public string SubredditId { get; }
        public string Thumbnail { get; }
        public string Title { get; }
        public string Url { get; }
        public string Permalink { get; }
        public bool IsExpanded { get; }
        public bool HasThumbnail { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}