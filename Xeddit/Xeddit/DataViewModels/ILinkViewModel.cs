namespace Xeddit.DataViewModels
{
    public interface ILinkViewModel
    {
        string Id { get; }
        string Name { get; }
        int? Ups { get; }
        int? Downs { get; }
        bool? Likes { get; }
        long? Created { get; }
        long? CreatedUtc { get; }
        string Author { get; }
        string Domain { get; }
        bool IsSelf { get; }
        int NumComments { get; }
        bool Over18 { get; }
        int Score { get; }
        string SelfText { get; }
        string PrefixedSubreddit { get; }
        string Subreddit { get; }
        string SubredditId { get; }
        string Thumbnail { get; }
        string Title { get; }
        string Url { get; }
        string Permalink { get; }
        bool IsExpanded { get; }
        bool HasThumbnail { get; }
    }
}