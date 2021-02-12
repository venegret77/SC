using Newtonsoft.Json;

namespace Common.Models
{
    public class ResultContainer
    {
        [JsonProperty("success")]
        public bool Success
        {
            get => Success;
            set => Success = value;
        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("snackbarType")]
        public string SnackbarType { get; set; }
    }

    public sealed class ResultContainer<TObject> : ResultContainer
    {
        [JsonProperty("content")]
        public TObject Content { get; set; }
    }
}
