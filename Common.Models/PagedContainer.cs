using Newtonsoft.Json;

namespace Common.Models
{
    public sealed class PagedContainer<TObject>
    {
        [JsonProperty("content")]
        public TObject Content { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
