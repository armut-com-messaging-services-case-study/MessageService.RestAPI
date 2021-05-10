using MessageService.RestAPI.Exceptions;
using Newtonsoft.Json;
using System;

namespace MessageService.RestAPI.Resources.Voice
{
    public class Recordings : MessageService.RestAPI.Resources.Voice.VoiceBaseResource<MessageService.RestAPI.Objects.Voice.Recording>
    {
        public Recordings(MessageService.RestAPI.Objects.Voice.Recording recording)
            : base("calls", recording)
        {
        }

        public override string Uri
        {
            get
            {
                return String.Format("{0}/{1}/legs/{2}/recordings/{3}", Name, ((MessageService.RestAPI.Objects.Voice.Recording)Object).CallId, ((MessageService.RestAPI.Objects.Voice.Recording)Object).LegId, Object.Id);
            }
        }

        public string DownloadUri
        {
            get
            {
                return String.Format("{0}/{1}/legs/{2}/recordings/{3}.wav", Name, ((MessageService.RestAPI.Objects.Voice.Recording)Object).CallId, ((MessageService.RestAPI.Objects.Voice.Recording)Object).LegId, Object.Id);
            }
        }

        public override void Deserialize(string resource)
        {
            try
            {
                Object = JsonConvert.DeserializeObject<MessageService.RestAPI.Objects.Voice.VoiceResponse<MessageService.RestAPI.Objects.Voice.Recording>>(resource);
            }
            catch (JsonSerializationException e)
            {
                throw new ErrorException("Received response in an unexpected format!", e);
            }
        }
    }
}
