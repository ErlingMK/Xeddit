using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xeddit.Services.Authentication
{
    internal class TokenRequest : ITokenRequest
    {
        public string ClientId { get; set; } = "5DPRO9Doai43XA";
        public bool ApplicationOnly { get; set; }

        public async Task<Tokens> GetJwt(string code = null)
        {
            var request = ApplicationOnly ? CreateApplicationOnlyRequest() : CreateAuthCodeRequest(code);

            string json;

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                json = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<Tokens>(json);
        }

        private HttpRequestMessage CreateAuthCodeRequest(string code)
        {
            var content = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", "com.moxnes.xeddit://logincallback")
            };

            var request = new HttpRequestMessage
            {
                Content = new FormUrlEncodedContent(content),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.reddit.com/api/v1/access_token")
            };

            var authenticationValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + string.Empty));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationValue);

            return request;
        }

        private HttpRequestMessage CreateApplicationOnlyRequest()
        {
            const string deviceIdKey = "device_id";

            string deviceId;

            if (Preferences.ContainsKey(deviceIdKey))
            {
                deviceId = Preferences.Get(deviceIdKey, string.Empty);
            }
            else
            {
                deviceId = DependencyService.Get<IUniqueIdGenerator>().GenerateDeviceId();
                Preferences.Set(deviceIdKey, deviceId);
            }

            var content = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "https://oauth.reddit.com/grants/installed_client"),
                new KeyValuePair<string, string>("device_id", deviceId)
            };

            var request = new HttpRequestMessage
            {
                Content = new FormUrlEncodedContent(content),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.reddit.com/api/v1/access_token")
            };

            var authenticationValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + string.Empty));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationValue);

            return request;
        }
    }

    public interface ITokenRequest
    {
        bool ApplicationOnly { get; set; }
        Task<Tokens> GetJwt(string code = null);
    }
}