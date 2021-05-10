using Newtonsoft.Json;

namespace MessageService.RestAPI.Objects.Conversations
{
    public class MessagesCount
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}