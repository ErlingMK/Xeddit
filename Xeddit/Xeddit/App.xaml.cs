using System;
using LightInject;
using Xamarin.Forms;
using Xeddit.Services;
using Xeddit.Views;
using Xeddit.Views.Comments;
using Xeddit.Views.Front;
using Xeddit.Views.Subreddit;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit
{
    public partial class App : Application
    {
        private ServiceContainer m_container;

        public App()
        {
            InitializeComponent();

            m_container = new ServiceContainer(new ContainerOptions() {EnablePropertyInjection = false});
            m_container.RegisterInstance(typeof(IServiceContainer), m_container);
            m_container.RegisterFrom<CompositionRoot>();

            MainPage = m_container.GetInstance<FrontPage>();
        }

        protected override async void OnStart()
        {
            m_container.GetInstance<INavigationService>().RegisterPages();
            await m_container.GetInstance<ISubredditPageViewModel>().Initialize();
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
