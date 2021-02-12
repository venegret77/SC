using Newtonsoft.Json;

namespace Common.Models
{
    public class ResultContainer
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("snackbarType")]
        public string SnackbarType { get; set; }

        public ResultContainer()
        {
            Success = false;
            SnackbarType = "";//TODO
        }
    }

    public sealed class ResultContainer<TObject> : ResultContainer
    {
        [JsonProperty("content")]
        public TObject Content { get; set; }
    }
}
