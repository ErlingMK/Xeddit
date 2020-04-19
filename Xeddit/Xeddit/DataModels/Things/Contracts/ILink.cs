using System.ComponentModel;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using Xamarin.Forms;
using Xeddit.DataModels.Things.InterfacesForThings;

namespace Xeddit.DataModels.Things.Contracts
{
    public interface ILink : IThing, IVotable, ICreated, INotifyPropertyChanged
    {
        string Author { get; set; }
        string Domain { get; set; }
        bool IsSelf { get; set; }
        int NumComments { get; set; }
        bool Over18 { get; set; }
        int Score { get; set; }
        string SelfText { get; set; }
        string PrefixedSubreddit { get; set; }
        string Subreddit { get; set; }
        string SubredditId { get; set; }
        string Thumbnail { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        int Ups { get; set; }
        int Downs { get; set; }
        bool? Likes { get; set; }
        long Created { get; set; }
        long CreatedUtc { get; set; }
        string Permalink { get; set; }
        bool IsExpanded { get; set; }
        bool HasThumbnail { get; }
    }
}