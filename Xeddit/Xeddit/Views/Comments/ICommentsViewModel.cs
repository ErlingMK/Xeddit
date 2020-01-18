using System.Collections.Generic;
using Xeddit.DataModels.Things;

namespace Xeddit.Views.Comments
{
    public interface ICommentsViewModel
    {
        void PreloadComments(string permalink);
        ILink CurrentLink { get; set; }
        IList<Comment> Comments { get; set; }
    }
}