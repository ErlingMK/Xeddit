using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Xeddit.Services.Http
{
    internal class HttpClientWrapper : IHttpClient
    {
        private HttpClient m_actualHttpClient;
        private readonly string m_baseAddress = "https://oauth.reddit.com";

        public HttpClientWrapper()
        {
            m_actualHttpClient = new HttpClient();
        }

        public async Task<string> GetAsync(Uri uri)
        {
            var response = await m_actualHttpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
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
