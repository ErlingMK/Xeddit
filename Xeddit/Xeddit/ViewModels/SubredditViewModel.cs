using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xeddit.Clients;
using Xeddit.DataModels.Things;
using Xeddit.ViewModels.Base;
using Xeddit.ViewModels.Interfaces;

namespace Xeddit.ViewModels
{
    public class SubredditViewModel : BaseViewModel, ISubredditViewModel
    {
        private readonly ILinkClient m_linkClient;
        private string m_after;
        private int m_count;
        private List<Link> m_links;
        private string m_currentSubreddit;

        public SubredditViewModel(ILinkClient linkClient)
        {
            m_linkClient = linkClient;

            Links = new List<Link>();
            CurrentSubreddit = "popular";

            SearchForSubredditCommand = new Command(async () => await SearchForSubreddit());
        }



        public List<Link> Links
        {
            get => m_links;
            set => SetProperty(ref m_links, value);
        }

        public string CurrentSubreddit
        {
            get => $"r/{m_currentSubreddit}";
            set => SetProperty(ref m_currentSubreddit, value);
        }

        public string SearchedForSubreddit { get; set; }

        public async Task Initialize()
        {
            var linksListing = await m_linkClient.GetLinksAsync("/r/popular/hot");
            m_after = linksListing.After;
            m_count = linksListing.Dist;

            Links = linksListing.Children.Select(thingWrapper => thingWrapper.Data as Link).ToList();
        }
        private async Task SearchForSubreddit()
        {
            var linksListing = await m_linkClient.GetLinksAsync($"/r/{SearchedForSubreddit}/hot");
            CurrentSubreddit = SearchedForSubreddit;
            Links = linksListing.Children.Select(thingWrapper => thingWrapper.Data as Link).ToList();
        }

        public ICommand SearchForSubredditCommand { get; set; }
    }
}
