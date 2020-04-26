using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;
using Xeddit.Clients;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.Services.Authentication.Abstractions;

namespace Xeddit.Views.Front.ViewModel
{
    public class SubredditViewModel : ISubredditViewModel
    {
        private string m_currentSubreddit;
        private readonly ILinkService m_linkService;
        private readonly ITokenRequest m_tokenRequest;
        private readonly ITokensContainer m_tokesContainer;
        private RangeObservableCollection<ILink> m_links = new RangeObservableCollection<ILink>();
        private bool m_isBusy;
        private bool m_isLoading;
        private string m_subredditSearchString;

        public SubredditViewModel(ITokenRequest tokenRequest, ITokensContainer tokesContainer, ILinkService linkService)
        {
            m_tokenRequest = tokenRequest;
            m_tokesContainer = tokesContainer;
            m_linkService = linkService;

            CurrentSubreddit = "askreddit";

            NextLinksCommand = new AsyncCommand(NextLinks, () => !m_isLoading);
            NewSubredditCommand = new AsyncCommand(NewSubreddit);
            GoToCommentsCommand = new Command<ILink>(GoToComments);
        }

        private void GoToComments(ILink link)
        {

        }

        private async Task NewSubreddit()
        {
            CurrentSubreddit = SubredditSearchString;
            IsBusy = true;

            await GetDefaultLinks(true);
        }

        private async Task NextLinks()
        {
            m_isLoading = true;
            try
            {
                var listing = await m_linkService.GetLinkListingAsync(m_currentSubreddit);
                foreach (var listingChild in listing.Children)
                {
                    Links.Add(listingChild.Data as Link);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            m_isLoading = false;
        }

        public RangeObservableCollection<ILink> Links
        {
            get => m_links;
            set => PropertyChanged.RaiseWhenSet(ref m_links, value, this);
        }

        public async Task Initialize()
        {
            IsBusy = true;

            await GetToken();

            await GetDefaultLinks();
        }

        public bool IsBusy
        {
            get => m_isBusy;
            set => PropertyChanged.RaiseWhenSet(ref m_isBusy, value);
        }

        public IAsyncCommand NextLinksCommand { get; }

        public string SubredditSearchString
        {
            get => m_subredditSearchString;
            set => PropertyChanged.RaiseWhenSet(ref m_subredditSearchString, value);
        }

        public IAsyncCommand NewSubredditCommand { get; }

        public string CurrentSubreddit
        {
            get => m_currentSubreddit;
            set => PropertyChanged.RaiseWhenSet(ref m_currentSubreddit, value);
        }

        public ICommand GoToCommentsCommand { get; }

        private async Task GetDefaultLinks(bool reset = false)
        {
            try
            {
                var listing = await m_linkService.GetLinkListingAsync(CurrentSubreddit, reset);
                OnListingsLoaded(listing);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void OnListingsLoaded(Listing listing)
        {
            var tempList = new List<ILink>();

            foreach (var thing in listing.Children)
            {
                tempList.Add(thing.Data as Link);
            }

            Links = new RangeObservableCollection<ILink>(tempList);
        }

        private async Task GetToken()
        {
            m_tokenRequest.ApplicationOnly = true;
            m_tokesContainer.Tokens = await m_tokenRequest.GetJwt();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}