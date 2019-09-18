using System;
using LightInject;
using Xamarin.Forms;

namespace Xeddit
{
    public partial class App : Application
    {
        private ServiceContainer m_container;
        private MainPage m_mainPage;

        public App()
        {
            InitializeComponent();

            m_container = new ServiceContainer(new ContainerOptions() {EnablePropertyInjection = false});
            m_container.RegisterFrom<CompositionRoot>();

            m_mainPage = m_container.GetInstance<MainPage>();
            MainPage = new NavigationPage(m_mainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void OnAuthorizationCallback(Uri callbackUri)
        {
            await m_mainPage.OnCallback(callbackUri);
        }
    }
}
