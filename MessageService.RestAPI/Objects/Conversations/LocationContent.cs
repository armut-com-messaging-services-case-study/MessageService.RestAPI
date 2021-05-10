using Newtonsoft.Json;

namespace MessageService.RestAPI.Objects.Conversations
{
    public class LocationContent
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}