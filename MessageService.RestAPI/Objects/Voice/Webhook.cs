using Newtonsoft.Json;
using System;

namespace MessageService.RestAPI.Objects.Voice
{

    public class Webhook : IIdentifiable<string>
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }

    public class WebhookList : VoiceBaseList<Webhook>
    {
    }
}