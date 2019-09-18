using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xeddit.DataModels.Things;

namespace Xeddit.ViewModels.Interfaces
{
    public interface ISubredditViewModel
    {
        List<Link> Links { get; set; }
        string CurrentSubreddit { get; set; }
        string SearchedForSubreddit { get; set; }
        Task Initialize();
        ICommand SearchForSubredditCommand { get; set; }
    }
}
