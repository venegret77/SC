using Newtonsoft.Json;

namespace Common.Models.Groups
{
    public sealed class GroupsQueryOptions : PaginationQueryOptions
    {
        [JsonProperty("name"), MaxJsonLength(nameof(Name), 25)]
        public string Name { get; set; }
    }
}
