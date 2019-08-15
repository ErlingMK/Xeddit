using System;
using System.Threading.Tasks;

namespace Xeddit.Services
{
    internal class HttpClient : IHttpClient
    {
        private HttpClient m_httpClient;
        private readonly string m_baseAddress = "https://oauth.reddit.com";

        public HttpClient()
        {
            m_httpClient = new HttpClient();
        }

        public Task GetAsync(Uri uri)
        {
            return Task.CompletedTask;
        }

        public Task PostAsync(Uri uri)
        {
            return Task.CompletedTask;
        }

        public Task PutAsync(Uri uri)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Uri uri)
        {
            return Task.CompletedTask;
        }
    }
}
