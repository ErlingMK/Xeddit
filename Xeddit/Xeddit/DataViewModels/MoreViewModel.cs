using System.Collections.Generic;
using Xeddit.DataViewModels.Contracts;

namespace Xeddit.DataViewModels
{
    public class MoreViewModel : IMoreViewModel
    {
        public MoreViewModel(int count, string parentId, int depth, List<string> children, string id, string name)
        {
            Count = count;
            ParentId = parentId;
            Depth = depth;
            Children = children;
            Id = id;
            Name = name;
        }

        public int Count { get; }
        public string ParentId { get; }
        public int Depth { get; }
        public List<string> Children { get; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
