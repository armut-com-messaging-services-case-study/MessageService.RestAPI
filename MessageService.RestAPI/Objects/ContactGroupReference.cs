using Newtonsoft.Json;

namespace MessageService.RestAPI.Objects
{
    public class ContactGroupReference
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
