using System.Collections.Generic;
using Xeddit.DataViewModels;

namespace Xeddit.DataModels.Things.Contracts
{
    public interface IMore : IThing
    {
        int Count { get; set; }
        string ParentId { get; set; }
        int Depth { get; set; }
        List<string> Children { get; set; }
    }
}