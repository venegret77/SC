using Common.Models.Dictionaries;
using Newtonsoft.Json;

namespace Common.Models.Students
{
    public sealed class StudentViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("gender")]
        public DictionaryViewModel Gender { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("identifer")]
        public string Identifer { get; set; }
    }
}
