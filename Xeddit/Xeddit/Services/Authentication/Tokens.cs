using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Xeddit.Services.Authentication
{
    public class Tokens
    {
        [JsonProperty("access_token")]public string AccessToken { get; set; }
        [JsonProperty("token_type")]public string TokenType { get; set; }
        [JsonProperty("expires_in")]public string ExpiresIn { get; set; }
        [JsonProperty("scope")]public string Scope { get; set; }
        [JsonProperty("refresh_token")]public string RefreshToken { get; set; }
    }
}
