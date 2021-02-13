using Newtonsoft.Json;
using System;

namespace Common.Models.Authorization
{
    public sealed class LoginOrRegistrationModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
