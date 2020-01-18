using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xeddit.Services.Authentication;
using Xeddit.Services.Authentication.Abstractions;

namespace Xeddit.Services.Http
{
    internal class HttpClientWrapper : IHttpClient
    {
        private readonly ITokensContainer m_tokensContainer;
        private HttpClient m_actualHttpClient;

        public HttpClientWrapper(ITokensContainer tokensContainer)
        {
            m_tokensContainer = tokensContainer;
            m_actualHttpClient = new HttpClient();
        }

        public async Task<string> GetAsync(Uri uri)
        {
            m_actualHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", m_tokensContainer.Tokens.AccessToken);

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
