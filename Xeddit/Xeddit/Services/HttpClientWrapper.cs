using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Xeddit.Services
{
    internal class HttpClientWrapper : IHttpClient
    {
        private HttpClient m_actualHttpClient;
        private readonly string m_baseAddress = "https://oauth.reddit.com";

        public HttpClientWrapper()
        {
            m_actualHttpClient = new HttpClient();
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
