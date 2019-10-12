using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xeddit.DataModels.Things;
using Xeddit.Models;
using Xeddit.Services.Authentication;
using Xeddit.ViewModels.Base;
using Xeddit.ViewModels.Interfaces;

namespace Xeddit.ViewModels
{
    public class SubredditViewModel : BaseViewModel, ISubredditViewModel
    {
        private const string m_defaultSubreddit = "popular";
        private readonly ICommentsViewModel m_commentsViewModel;
        private readonly ILinkModel m_linkModel;
        private readonly ITokenRequest m_tokenRequest;
        private readonly ITokensContainer m_tokesContainer;
        private string m_currentSubreddit;
        private List<Link> m_links;
        private bool m_searchEntryIsVisible;

        public SubredditViewModel(ITokenRequest tokenRequest, ILinkModel linkModel, ITokensContainer tokesContainer,
            ICommentsViewModel commentsViewModel)
        {
            m_tokenRequest = tokenRequest;
            m_linkModel = linkModel;
            m_tokesContainer = tokesContainer;
            m_commentsViewModel = commentsViewModel;

            Links = new List<Link>();
            CurrentSubreddit = m_defaultSubreddit;

            SearchForSubredditCommand = new Command(async () => await SearchForSubreddit());

            NextPageCommand = new Command(async () => await NextPage());

            LinkSelectedCommand = new Command(async () => await LinkSelected());
        }

        public int NumberOfLinks { get; set; }

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
        public ILink SelectedLink { get; set; }

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

        public ICommand SearchForSubredditCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand LinkSelectedCommand { get; set; }

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

        private async Task LinkSelected()
        {
            m_commentsViewModel.PreloadComments(SelectedLink.Permalink);
        }
    }
}