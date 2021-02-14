using Newtonsoft.Json;

namespace Common.Models.Groups
{
    public sealed class UpdateGroupModel : AddGroupModel
    {
        [JsonProperty("groupId")]
        public long GroupId { get; set; }
    }
}
