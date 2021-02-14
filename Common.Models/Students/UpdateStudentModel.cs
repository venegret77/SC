using Newtonsoft.Json;

namespace Common.Models.Students
{
    public sealed class UpdateStudentModel : AddOrUpdateStudentModel
    {
        [JsonProperty("studentId")]
        public long StudentId { get; set; }
    }
}
