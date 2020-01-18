using LightInject;
using Xeddit.Clients;
using Xeddit.DataModels.Things;
using Xeddit.Models;
using Xeddit.Services;
using Xeddit.Services.Authentication;
using Xeddit.Services.Authentication.Abstractions;
using Xeddit.Services.Http;
using Xeddit.ViewModels;
using Xeddit.Views;
using Xeddit.Views.Comments;
using Xeddit.Views.Front;

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
            serviceRegistry.Register<ICommentsModel, CommentsModel>(new PerContainerLifetime());
        }

        private void RegisterViewModels(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ISubredditViewModel, SubredditViewModel>();
            serviceRegistry.Register<ICommentsViewModel, CommentsViewModel>();
        }

        private void RegisterViews(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<TabbedPage>();
            serviceRegistry.Register<SubredditPage>();
            serviceRegistry.Register<CommentsPage>();
        }

        private void RegisterServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IHttpClient, HttpClientWrapper>(new PerContainerLifetime());
            serviceRegistry.Register<IHttpFactory, HttpFactory>(new PerContainerLifetime());

            serviceRegistry.Register<IBrowser, Browser>(new PerContainerLifetime());
            serviceRegistry.Register<IAuthorizationRequest, AuthorizationRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ITokenRequest, TokenRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ITokensContainer, TokensContainer>(new PerContainerLifetime());
        }

        private void RegisterClients(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILinkClient, LinkClient>(new PerContainerLifetime());
            serviceRegistry.Register<ICommentClient, CommentClient>(new PerContainerLifetime());
        }
    }
}
