using MessageService.RestAPI.Exceptions;
using Newtonsoft.Json;

namespace MessageService.RestAPI.Resources.Voice
{
    public class Webhooks : VoiceBaseResource<MessageService.RestAPI.Objects.Voice.Webhook>
    {
        public Webhooks(Objects.Voice.Webhook webhook) : base("webhooks", webhook) { }
        public Webhooks() : this(new Objects.Voice.Webhook()) { }

        public override void Deserialize(string resource)
        {
            try
            {
                Object = JsonConvert.DeserializeObject<MessageService.RestAPI.Objects.Voice.VoiceResponse<MessageService.RestAPI.Objects.Voice.Webhook>>(resource);
            }
            catch (JsonSerializationException e)
            {
                throw new ErrorException("Received response in an unexpected format!", e);
            }
        }

        // Override the serialize function to remove the ID from the body of an update message (PUT)

        public override string Serialize()
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(new { ((MessageService.RestAPI.Objects.Voice.Webhook)Object).url, ((MessageService.RestAPI.Objects.Voice.Webhook)Object).token }, settings);
        }
    }
}
