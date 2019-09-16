using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xeddit.Clients;
using Xeddit.Services.Authentication;

namespace Xeddit
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IAuthorizationRequest m_authorizationRequest;
        private readonly ITokenRequest m_tokenRequest;
        private readonly ITokensContainer m_tokensContainer;
        private readonly ILinkClient m_linkClient;

        public MainPage(IAuthorizationRequest authorizationRequest, ITokenRequest tokenRequest, ITokensContainer tokensContainer, ILinkClient linkClient)
        {
            m_authorizationRequest = authorizationRequest;
            m_tokenRequest = tokenRequest;
            m_tokensContainer = tokensContainer;
            m_linkClient = linkClient;
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            m_authorizationRequest.StartAuthRequest();
        }

        public async Task OnCallback(Uri callbackUri)
        {
            var authorizationResponse = new AuthorizationResponse(callbackUri);

            if (!authorizationResponse.ErrorOccured)
            {
                m_tokensContainer.Tokens = await m_tokenRequest.GetJwt(authorizationResponse.Code);
            }
            else
            {
                return;
            }

        }

        private async void Button_OnClicked_AppOnly(object sender, EventArgs e)
        {
            m_tokenRequest.ApplicationOnly = true;
            m_tokensContainer.Tokens = await m_tokenRequest.GetJwt();

            var listing = await m_linkClient.GetLinksAsync("/r/askreddit/hot");

            var id = 2;
        }
    }
}
