using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xeddit.DataModels.Things;

namespace Xeddit.Views.Front
{
    public interface ISubredditViewModel
    {
        List<Link> Links { get; set; }
        string CurrentSubreddit { get; set; }
        string SearchedForSubreddit { get; set; }
        bool SearchEntryIsVisible { get; set; }
        ILink SelectedLink { get; set; }
        Task Initialize();
        ICommand SearchForSubredditCommand { get; set; }
        ICommand NextPageCommand { get; set; }
        ICommand LinkSelectedCommand { get; set; }
    }
}
