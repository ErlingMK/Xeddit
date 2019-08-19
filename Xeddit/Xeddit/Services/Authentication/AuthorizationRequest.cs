using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using UriBuilder = System.UriBuilder;

namespace Xeddit.Services.Authentication
{
    public interface IAuthorizationRequest
    {
        Task StartAuthRequest();
    }

    internal class AuthorizationRequest : IAuthorizationRequest
    {
        private readonly IBrowser m_browser;

        public AuthorizationRequest(IBrowser browser)
        {
            m_browser = browser;
        }

        private Uri BuildUri()
        {
            var uriBuilder = new UriBuilder {
                Scheme = "https",
                Host = "www.reddit.com",
                Path = "api/v1/authorize.compact"};

            var queries = HttpUtility.ParseQueryString(uriBuilder.Query);
                
            queries["client_id"] = "5DPRO9Doai43XA";
            queries["response_type"] = "code";
            queries["state"] = "something";
            queries["redirect_uri"] = "com.moxnes.xeddit://logincallback";
            queries["duration"] = "permanent";
            queries["scope"] = "mysubreddits read submit";

            uriBuilder.Query = queries.ToString();

            return uriBuilder.Uri;
        }

        public Task StartAuthRequest()
        {
            m_browser.GetAsync(BuildUri());

            return Task.CompletedTask;
        }
    }
}
