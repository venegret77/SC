using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Models.Students
{
    public sealed class StudentsQueryOptions : PaginationQueryOptions
    {
        [JsonProperty("genderId")]
        public long? GenderId { get; set; }

        [JsonProperty("name"), MaxJsonLength(nameof(Name), 140)]
        public string Name { get; set; }

        [JsonProperty("identifer"), MaxJsonLength(nameof(Identifer), 16)]
        public string Identifer { get; set; }

        [JsonProperty("groupIds")]
        public List<long> GroupIds { get; set; }
    }
}
