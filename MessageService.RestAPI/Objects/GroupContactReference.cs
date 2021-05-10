using Newtonsoft.Json;

namespace MessageService.RestAPI.Objects
{
    public class GroupContactReference
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
