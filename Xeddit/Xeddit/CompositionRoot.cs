using LightInject;
using Xamarin.Forms;
using Xeddit.Clients;
using Xeddit.Clients.Abstractions;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.Mappers;
using Xeddit.Services;
using Xeddit.Services.Authentication;
using Xeddit.Services.Authentication.Abstractions;
using Xeddit.Services.Http;
using Xeddit.ViewModels;
using Xeddit.Views;
using Xeddit.Views.Comments;
using Xeddit.Views.Front;
using Xeddit.Views.Front.ViewModel;
using Xeddit.Views.Subreddit;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.SetDefaultLifetime<PerRequestLifeTime>();

            RegisterViews(serviceRegistry);
            RegisterViewModels(serviceRegistry);
            RegisterServices(serviceRegistry);
        }

        private void RegisterViewModels(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ISubredditViewModel, SubredditViewModel>(new PerContainerLifetime());
            serviceRegistry.Register<ICommentsViewModel, CommentsViewModel>(new PerContainerLifetime());
            serviceRegistry.Register<IFrontViewModel, FrontViewModel>(new PerContainerLifetime());
        }

        private void RegisterViews(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<FrontPage>();
            serviceRegistry.Register(fac => new NavigationPage(fac.GetInstance<FrontPage>()), new PerContainerLifetime());
        }

        private void RegisterServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IHttpClient, HttpClientWrapper>(new PerContainerLifetime());
            serviceRegistry.Register<IHttpFactory, HttpFactory>(new PerContainerLifetime());

            serviceRegistry.Register<IBrowser, Browser>(new PerContainerLifetime());
            serviceRegistry.Register<IAuthorizationRequest, AuthorizationRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ITokenRequest, TokenRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ILinkService, LinkService>();
            serviceRegistry.Register<ICommentsService, CommentsService>();
            serviceRegistry.Register<ITokensContainer, TokensContainer>(new PerContainerLifetime());
            serviceRegistry.Register<IThingMapper, ThingMapper>();
            serviceRegistry.Register<INavigationService, NavigationService>(new PerContainerLifetime());
        }

    }
}
