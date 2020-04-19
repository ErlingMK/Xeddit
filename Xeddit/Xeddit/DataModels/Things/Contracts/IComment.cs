using System.Collections.Generic;
using Xeddit.DataModels.Things.InterfacesForThings;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataModels.Things.Contracts
{
    public interface IComment : IVotable, ICreated
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
    }
}