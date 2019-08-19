using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Xeddit.Services.Authentication
{
    internal class TokenRequest : ITokenRequest
    {
        public async Task<Tokens> GetJwt(string callbackQuery = null)
        {
            var request = ApplicationOnly ? CreateApplicationOnlyRequest() : CreateAuthCodeRequest(callbackQuery);

            string json;

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                json = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<Tokens>(json);
        }

        private HttpRequestMessage CreateAuthCodeRequest(string callbackQuery)
        {
            var queriesCollection = System.Web.HttpUtility.ParseQueryString(callbackQuery);
            var code = queriesCollection.Get("code");

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri","com.moxnes.xeddit://logincallback")
            };

            var request = new HttpRequestMessage()
            {
                Content = new FormUrlEncodedContent(pairs),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.reddit.com/api/v1/access_token")
            };

            var authenticationValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + string.Empty));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationValue);

            return request;
        }

        private HttpRequestMessage CreateApplicationOnlyRequest()
        {
            var deviceId = !Xamarin.Essentials.Preferences.ContainsKey("device_id") ? DependencyService.Get<IUniqueIdGenerator>().GenerateDeviceId() : Xamarin.Essentials.Preferences.Get("device_id", string.Empty);

            Xamarin.Essentials.Preferences.Set("device_id", deviceId);


            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "https://oauth.reddit.com/grants/installed_client"),
                new KeyValuePair<string, string>("device_id", deviceId)
            };

            var request = new HttpRequestMessage()
            {
                Content = new FormUrlEncodedContent(pairs),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.reddit.com/api/v1/access_token")
            };
            var authenticationValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + string.Empty));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationValue);
            return request;
        }

        public bool ApplicationOnly { get; set; }

        public string ClientId { get; set; } = "5DPRO9Doai43XA";
    }

    public interface ITokenRequest
    {
        Task<Tokens> GetJwt(string callbackQuery = null);
        bool ApplicationOnly { get; set; }
    }
}
