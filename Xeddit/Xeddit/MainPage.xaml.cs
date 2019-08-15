using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xeddit.Services.Authentication;

namespace Xeddit
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IAuthorizationRequest m_authorizationRequest;

        public MainPage(IAuthorizationRequest authorizationRequest)
        {
            m_authorizationRequest = authorizationRequest;
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            m_authorizationRequest.StartAuthRequest();
        }
    }
}
