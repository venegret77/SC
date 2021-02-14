using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Models.Students
{
    public class AddOrUpdateStudentModel
    {
        [JsonProperty("genderId")]
        public long GenderId { get; set; }

        [JsonProperty("lastName"), MaxJsonLength(nameof(LastName), 40)]
        public string LastName { get; set; }

        [JsonProperty("firstName"), MaxJsonLength(nameof(FirstName), 40)]
        public string FirstName { get; set; }

        [JsonProperty("middleName"), MaxJsonLength(nameof(MiddleName), 60)]
        public string MiddleName { get; set; }

        [JsonProperty("identifer"), MaxJsonLength(nameof(Identifer), 16)]
        public string Identifer { get; set; }

        [JsonProperty("groupIds")]
        public List<long> GroupIds { get; set; }
    }
}
