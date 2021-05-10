using MessageService.RestAPI.Exceptions;
using Newtonsoft.Json;


namespace MessageService.RestAPI.Resources.Voice
{
    public class Calls : VoiceBaseResource<MessageService.RestAPI.Objects.Voice.Call>
    {
        public Calls(Objects.Voice.Call call) : base("calls", call) { }
        public Calls() : this(new Objects.Voice.Call()) { }

        public override void Deserialize(string resource)
        {
            try
            {
                Object = JsonConvert.DeserializeObject<MessageService.RestAPI.Objects.Voice.VoiceResponse<MessageService.RestAPI.Objects.Voice.Call>>(resource);
            }
            catch (JsonSerializationException e)
            {
                throw new ErrorException("Received response in an unexpected format!", e);
            }
        }
    }
}