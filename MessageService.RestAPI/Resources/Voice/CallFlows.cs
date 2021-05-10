using MessageService.RestAPI.Exceptions;
using MessageService.RestAPI.Net;
using MessageService.RestAPI.Objects.Voice;
using Newtonsoft.Json;

namespace MessageService.RestAPI.Resources.Voice
{
    public class CallFlows : VoiceBaseResource<MessageService.RestAPI.Objects.Voice.CallFlow>
    {
        public CallFlows(MessageService.RestAPI.Objects.Voice.CallFlow callFlow) : base("call-flows", callFlow) { }
        public CallFlows() : this(new MessageService.RestAPI.Objects.Voice.CallFlow()) { }

        public override UpdateMode UpdateMode
        {
            get { return UpdateMode.Put; }
        }

        public override void Deserialize(string resource)
        {
            try
            {
                Object = JsonConvert.DeserializeObject<VoiceResponse<CallFlow>>(resource);
            }
            catch (JsonSerializationException e)
            {
                throw new ErrorException("Received response in an unexpected format!", e);
            }
        }
    }
}