using LightInject;
using Xeddit.Clients;
using Xeddit.Models;
using Xeddit.Services;
using Xeddit.Services.Authentication;
using Xeddit.Services.Http;
using Xeddit.ViewModels;
using Xeddit.ViewModels.Interfaces;
using Xeddit.Views;

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
            RegisterClients(serviceRegistry);
            RegisterModels(serviceRegistry);
        }

        private void RegisterModels(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILinkModel, LinkModel>(new PerContainerLifetime());
        }

        private void RegisterViewModels(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ISubredditViewModel, SubredditViewModel>();
        }

        private void RegisterViews(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<MainPage>();
            serviceRegistry.Register<SubredditPage>();
        }

        private void RegisterServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IHttpClient, HttpClientWrapper>(new PerContainerLifetime());
            serviceRegistry.Register<IHttpFactory, HttpFactory>(new PerContainerLifetime());

            serviceRegistry.Register<IBrowser, Browser>();
            serviceRegistry.Register<IAuthorizationRequest, AuthorizationRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ITokenRequest, TokenRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ITokensContainer, TokensContainer>(new PerContainerLifetime());
        }

        private void RegisterClients(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILinkClient, LinkClient>(new PerContainerLifetime());
        }
    }
}
