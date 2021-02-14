using Newtonsoft.Json;

namespace Common.Models.Groups
{
    public class AddGroupModel
    {
        [JsonProperty("name"), MaxJsonLength(nameof(Name), 25)]
        public string Name { get; set; }
    }
}
