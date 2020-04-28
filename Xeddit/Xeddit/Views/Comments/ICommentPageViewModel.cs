using System.Threading.Tasks;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;

namespace Xeddit.Views.Comments
{
    public interface ICommentPageViewModel
    {
        ILinkViewModel CurrentLink { get; }
        Task Initialize(ILinkViewModel link);
    }
}