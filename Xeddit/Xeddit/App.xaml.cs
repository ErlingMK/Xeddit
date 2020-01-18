using System;
using LightInject;
using Xamarin.Forms;
using Xeddit.Views;
using TabbedPage = Xeddit.Views.TabbedPage;

namespace Xeddit
{
    public partial class App : Application
    {
        private ServiceContainer m_container;
        private TabbedPage m_tabbedPage;

        public App()
        {
            InitializeComponent();

            m_container = new ServiceContainer(new ContainerOptions() {EnablePropertyInjection = false});
            m_container.RegisterFrom<CompositionRoot>();

            //m_tabbedPage = m_container.GetInstance<TabbedPage>();
            //TabbedPage = new NavigationPage(m_tabbedPage);

            MainPage = m_container.GetInstance<TabbedPage>();
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
            //await m_tabbedPage.OnCallback(callbackUri);
        }
    }
}
