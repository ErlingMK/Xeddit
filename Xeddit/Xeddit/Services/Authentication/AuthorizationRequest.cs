using System;
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

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["client_id"] = "5DPRO9Doai43XA";
            query["response_type"] = "code";
            query["state"] = "something"; // TODO: Randomly generate
            query["redirect_uri"] = "com.moxnes.xeddit://logincallback";
            query["duration"] = "permanent";
            query["scope"] = "mysubreddits read submit";
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        public Task StartAuthRequest()
        {
            m_browser.GetAsync(BuildUri());

            return Task.CompletedTask;
        }
    }
}
