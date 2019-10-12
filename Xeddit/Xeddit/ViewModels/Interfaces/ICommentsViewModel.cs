using System.Collections.Generic;
using Xeddit.DataModels.Things;

namespace Xeddit.ViewModels.Interfaces
{
    public interface ICommentsViewModel
    {
        void PreloadComments(string permalink);
        ILink CurrentLink { get; set; }
        IList<Comment> Comments { get; set; }
    }
}