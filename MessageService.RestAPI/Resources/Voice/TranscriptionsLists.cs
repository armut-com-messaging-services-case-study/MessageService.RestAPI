using System;

namespace MessageService.RestAPI.Resources.Voice
{
    public class TranscriptionsLists : VoiceBaseLists<MessageService.RestAPI.Objects.Voice.Transcription>
    {
        public TranscriptionsLists(string callId, string legId, string recordingId)
            : base("transcriptions", new MessageService.RestAPI.Objects.Voice.TranscriptionList { CallId = callId, LegId = legId, RecordingId = recordingId })
        { }

        public TranscriptionsLists(Objects.Voice.TranscriptionList list) : base("transcriptions", list) { }

        public override string Uri
        {
            get
            {
                return String.Format("calls/{0}/legs/{1}/recordings/{2}/{3}", ((MessageService.RestAPI.Objects.Voice.TranscriptionList)Object).CallId, ((MessageService.RestAPI.Objects.Voice.TranscriptionList)Object).LegId, ((MessageService.RestAPI.Objects.Voice.TranscriptionList)Object).RecordingId, Name);
            }
        }
    }
}
