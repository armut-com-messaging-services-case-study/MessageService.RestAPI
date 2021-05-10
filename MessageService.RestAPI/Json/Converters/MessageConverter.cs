using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MessageService.RestAPI.Json.Converters
{
    class MessageConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var message = value as MessageService.RestAPI.Objects.Message;
            var toSerialize = new Dictionary<string, string>();

            if (message == null)
            {
                toSerialize.Add("href", null);
            }
            else
            {
                toSerialize.Add("href", message.Href);
            }
            serializer.Serialize(writer, toSerialize);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<MessageService.RestAPI.Objects.Message>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(MessageService.RestAPI.Objects.Message).IsAssignableFrom(objectType);
        }
    }
}
