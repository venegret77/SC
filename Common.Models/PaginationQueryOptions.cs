using Newtonsoft.Json;

namespace Common.Models
{
    public class PaginationQueryOptions
    {
        [JsonProperty("skip")]
        public int? Skip { get; set; }

        [JsonProperty("take")]
        public int? Take { get; set; }
    }
}
