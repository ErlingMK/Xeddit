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
using Xeddit.Services;
using Xeddit.Services.Authentication.Abstractions;
using Xeddit.Views.Comments;

namespace Xeddit.Views.Front.ViewModel
{
    public class SubredditViewModel : ISubredditViewModel
    {
        private const string m_defaultSubreddit = "askreddit";
        private readonly ILinkService m_linkService;
        private readonly INavigationService m_navigationService;
        private readonly ICommentsViewModel m_commentsViewModel;
        private readonly ITokenRequest m_tokenRequest;
        private readonly ITokensContainer m_tokesContainer;
        private ObservableCollection<ILink> m_links = new ObservableCollection<ILink>();
        private bool m_isBusy;

        public SubredditViewModel(ITokenRequest tokenRequest, ITokensContainer tokesContainer, ILinkService linkService, INavigationService navigationService, ICommentsViewModel commentsViewModel)
        {
            m_tokenRequest = tokenRequest;
            m_tokesContainer = tokesContainer;
            m_linkService = linkService;
            m_navigationService = navigationService;
            m_commentsViewModel = commentsViewModel;

            GoToCommentsCommand = new AsyncCommand<ILink>(GoToComments);
        }

        private async Task GoToComments(ILink link)
        {
            await m_navigationService.NavigateTo<ICommentsViewModel>(async () => await m_commentsViewModel.LoadComments(link));
        }

        public ObservableCollection<ILink> Links
        {
            get => m_links;
            set => PropertyChanged.RaiseWhenSet(ref m_links, value);
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

        public IAsyncCommand<ILink> GoToCommentsCommand { get; }

        private async Task GetDefaultLinks()
        {
            try
            {
                var listing = await m_linkService.GetLinkListingAsync(m_defaultSubreddit);
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

            Links = new ObservableCollection<ILink>(tempList);
        }

        private async Task GetToken()
        {
            m_tokenRequest.ApplicationOnly = true;
            m_tokesContainer.Tokens = await m_tokenRequest.GetJwt();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}