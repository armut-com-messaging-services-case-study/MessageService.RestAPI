using MessageService.RestAPI.Exceptions;
using Newtonsoft.Json;
using System;

namespace MessageService.RestAPI.Resources.Voice
{
    public class Transcriptions : VoiceBaseResource<MessageService.RestAPI.Objects.Voice.Transcription>
    {
        public Transcriptions(MessageService.RestAPI.Objects.Voice.Transcription transcription)
            : base("calls", transcription)
        {
        }

        public override string Uri
        {
            get
            {
                return String.Format("{0}/{1}/legs/{2}/recordings/{3}/transcriptions/{4}", Name, ((MessageService.RestAPI.Objects.Voice.Transcription)Object).CallId, ((MessageService.RestAPI.Objects.Voice.Transcription)Object).LegId, ((MessageService.RestAPI.Objects.Voice.Transcription)Object).RecordingId, Object.Id);
            }
        }

        public string DownloadUri
        {
            get
            {
                return String.Format("{0}/{1}/legs/{2}/recordings/{3}/transcriptions/{4}.txt", Name, ((MessageService.RestAPI.Objects.Voice.Transcription)Object).CallId, ((MessageService.RestAPI.Objects.Voice.Transcription)Object).LegId, ((MessageService.RestAPI.Objects.Voice.Transcription)Object).RecordingId, Object.Id);
            }
        }

        public override string Serialize()
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(new { ((MessageService.RestAPI.Objects.Voice.Transcription)Object).Language }, settings);
        }

        public override void Deserialize(string resource)
        {
            try
            {
                Object = JsonConvert.DeserializeObject<MessageService.RestAPI.Objects.Voice.VoiceResponse<MessageService.RestAPI.Objects.Voice.Transcription>>(resource);
            }
            catch (JsonSerializationException e)
            {
                throw new ErrorException("Received response in an unexpected format!", e);
            }
        }
    }
}
