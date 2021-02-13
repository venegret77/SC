using Common.JWT;
using Newtonsoft.Json;

namespace Common.Models.Authorization
{
    public sealed class AccountViewModel
    {
        [JsonProperty("login"), MaxJsonLength(nameof(Login), 50)]
        public string Login { get; set; }

        [JsonProperty("accessToken")]
        public TokenModel AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public TokenModel RefreshToken { get; set; }
    }
}
