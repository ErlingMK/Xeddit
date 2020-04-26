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
        object Replies { get; set; }
        int? Score { get; set; }
        string Subreddit { get; set; }
        string SubredditId { get; set; }
    }
}