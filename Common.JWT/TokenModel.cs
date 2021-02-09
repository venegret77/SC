using Newtonsoft.Json;
using System;

namespace Common.JWT
{
    /// <summary>
    /// Токен
    /// </summary>
    public sealed class TokenModel : ICloneable
    {
        [JsonRequired]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonRequired]
        [JsonProperty("expirationTime")]
        public int ExpirationTime { get; set; }

        public object Clone()
        {
            return new TokenModel
            {
                Token = Token?.Clone() as string,
                ExpirationTime = ExpirationTime
            };
        }
    }
}
