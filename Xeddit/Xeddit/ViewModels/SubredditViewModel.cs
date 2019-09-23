using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xeddit.Clients;
using Xeddit.DataModels.Things;
using Xeddit.Models;
using Xeddit.Services.Authentication;
using Xeddit.ViewModels.Base;
using Xeddit.ViewModels.Interfaces;

namespace Xeddit.ViewModels
{
    public class SubredditViewModel : BaseViewModel, ISubredditViewModel
    {
        private readonly ITokenRequest m_tokenRequest;
        private readonly ILinkModel m_linkModel;
        private readonly ITokensContainer m_tokesContainer;
        private List<Link> m_links;
        private string m_currentSubreddit;
        private bool m_searchEntryIsVisible;

        private const string m_defaultSubreddit = "popular";

        public SubredditViewModel(ITokenRequest tokenRequest, ILinkModel linkModel, ITokensContainer tokesContainer)
        {
            m_tokenRequest = tokenRequest;
            m_linkModel = linkModel;
            m_tokesContainer = tokesContainer;

            Links = new List<Link>();
            CurrentSubreddit = m_defaultSubreddit;

            SearchForSubredditCommand = new Command(async () => await SearchForSubreddit());

            NextPageCommand = new Command(async () => await NextPage());
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
        public int NumberOfLinks { get; set; }
        public bool SearchEntryIsVisible
        {
            get => m_searchEntryIsVisible;
            set => SetProperty(ref m_searchEntryIsVisible, value);
        }

        public async Task Initialize()
        {
            m_tokenRequest.ApplicationOnly = true;
            m_tokesContainer.Tokens = await m_tokenRequest.GetJwt();

            Links = await m_linkModel.GetLinksForSubredditAsync(m_defaultSubreddit, LinkCategory.Hot, limit: 25);

            NumberOfLinks = Links.Count;
        }   
        private async Task SearchForSubreddit()
        {
            Links = await m_linkModel.GetLinksForSubredditAsync(SearchedForSubreddit, LinkCategory.Hot, limit: 25);

            Device.BeginInvokeOnMainThread(() => SearchEntryIsVisible = false);

            CurrentSubreddit = SearchedForSubreddit;
        }

        private async Task NextPage()
        {
            Links.Clear();

            Links = await m_linkModel.GetLinksForSubredditAsync(m_currentSubreddit, LinkCategory.Hot, limit: 25);
        }

        public ICommand SearchForSubredditCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
    }
}
