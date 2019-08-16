using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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

        public MainPage(IAuthorizationRequest authorizationRequest, ITokenRequest tokenRequest)
        {
            m_authorizationRequest = authorizationRequest;
            m_tokenRequest = tokenRequest;
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            m_authorizationRequest.StartAuthRequest();
        }

        public async Task OnCallback(string queries)
        {
            var queryStrings = queries.Split('&');
            var codeQuery = queryStrings.First(s => s.Contains("code"));
            var code = codeQuery.Split('=').Last();

            var token = await m_tokenRequest.GetJwt(code);

            var i = 2;
        }
    }
}
