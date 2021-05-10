using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessageService.RestAPI.Objects.Conversations
{
    public enum ConversationStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "archived")]
        Archived,
    }
    public class Conversation : IIdentifiable<string>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("contactId")]
        public string ContactId { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("messages")]
        public MessagesCount Messages { get; set; }

        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public ConversationStatus Status { get; set; }

        [JsonProperty("createdDatetime")]
        public DateTime? CreatedDatetime { get; set; }

        [JsonProperty("updatedDatetime")]
        public DateTime? UpdatedDatetime { get; set; }

        [JsonProperty("lastReceivedDatetime")]
        public DateTime? LastReceivedDatetime { get; set; }

        [JsonProperty("lastUsedChannelId")]
        public string LastUsedChannelId { get; set; }
    }
}