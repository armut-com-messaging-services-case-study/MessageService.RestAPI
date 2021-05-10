using Newtonsoft.Json;

namespace MessageService.RestAPI.Objects.Conversations
{
    public class MediaContent
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }
    }
}
