using LightInject;
using Xeddit.Services;
using Xeddit.Services.Authentication;

namespace Xeddit
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.SetDefaultLifetime<PerRequestLifeTime>();

            RegisterViews(serviceRegistry);
            RegisterServices(serviceRegistry);
        }

        private void RegisterViews(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<MainPage>();
        }

        private void RegisterServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IHttpClient, HttpClientWrapper>(new PerContainerLifetime());
            serviceRegistry.Register<IHttpFactory, HttpFactory>(new PerContainerLifetime());

            serviceRegistry.Register<IBrowser, Browser>();
            serviceRegistry.Register<IAuthorizationRequest, AuthorizationRequest>(new PerContainerLifetime());
            serviceRegistry.Register<ITokenRequest, TokenRequest>(new PerContainerLifetime());
        }
    }
}
