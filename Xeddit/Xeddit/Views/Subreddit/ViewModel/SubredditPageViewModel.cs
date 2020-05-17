using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using DIPS.Xamarin.UI.Commands;
using DIPS.Xamarin.UI.Extensions;
using Xeddit.Clients;
using Xeddit.Clients.Abstractions;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataViewModels;
using Xeddit.DataViewModels.Contracts;
using Xeddit.Services.Authentication.Abstractions;

namespace Xeddit.Views.Subreddit.ViewModel
{
    public class SubredditPageViewModel : ISubredditPageViewModel
    {
        private readonly ILinkService m_linkService;
        private readonly ISubredditService m_subredditService;
        private readonly ITokenRequest m_tokenRequest;
        private readonly ITokensContainer m_tokesContainer;
        private string m_currentSubreddit;
        private bool m_isBusy;
        private bool m_isLoading;
        private RangeObservableCollection<ILinkViewModel> m_links = new RangeObservableCollection<ILinkViewModel>();
        private string m_subredditSearchString;
        private RangeObservableCollection<ISubredditViewModel> m_subreddits = new RangeObservableCollection<ISubredditViewModel>();

        public SubredditPageViewModel(ITokenRequest tokenRequest, ITokensContainer tokesContainer, ILinkService linkService, ISubredditService subredditService)
        {
            m_tokenRequest = tokenRequest;
            m_tokesContainer = tokesContainer;
            m_linkService = linkService;
            m_subredditService = subredditService;

            CurrentSubreddit = "askreddit";

            NextLinksCommand = new AsyncCommand(async () => await GetLinks(), () => !m_isLoading);
            NewSubredditCommand = new AsyncCommand<ISubredditViewModel>(NewSubreddit);
        }

        public RangeObservableCollection<ILinkViewModel> Links
        {
            get => m_links;
            set => PropertyChanged.RaiseWhenSet(ref m_links, value, this);
        }

        public RangeObservableCollection<ISubredditViewModel> Subreddits
        {
            get => m_subreddits;
            set => PropertyChanged.RaiseWhenSet(ref m_subreddits, value);
        }

        public async Task Initialize()
        {
            IsBusy = true;

            await GetToken();

            await GetLinks();

            await GetSubreddits();
        }

        private async Task GetSubreddits()
        {
            try
            {
                var popularSubreddits = await m_subredditService.GetPopularSubreddits();
                Subreddits.AddRange(popularSubreddits);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
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

        public IAsyncCommand<ISubredditViewModel> NewSubredditCommand { get; }

        public string CurrentSubreddit
        {
            get => m_currentSubreddit;
            set => PropertyChanged.RaiseWhenSet(ref m_currentSubreddit, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task NewSubreddit(ISubredditViewModel subredditViewModel)
        {
            CurrentSubreddit = subredditViewModel.DisplayName;
            IsBusy = true;

            await GetLinks(true);
        }

        private async Task GetLinks(bool reset = false)
        {
            m_isLoading = true;
            if (reset) Links.Clear();
            try
            {
                var links = await m_linkService.GetLinkListingAsync(CurrentSubreddit, reset);
                Links.AddRange(links);
                IsBusy = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                m_isLoading = false;
            }
        }

        private async Task GetToken()
        {
            m_tokenRequest.ApplicationOnly = true;
            m_tokesContainer.Tokens = await m_tokenRequest.GetJwt();
        }
    }
}