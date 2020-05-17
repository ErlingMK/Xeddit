using System.Collections.Generic;
using Xeddit.DataModels.Things;

namespace Xeddit.DataViewModels.Contracts
{
    public interface IMoreViewModel : IThing, ICommentGroup
    {
        int Count { get; }
        string ParentId { get;}
        int Depth { get; }
        List<string> Children { get;}
    }
}