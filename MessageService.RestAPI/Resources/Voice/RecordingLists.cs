using System;

namespace MessageService.RestAPI.Resources.Voice
{
    public class RecordingLists : MessageService.RestAPI.Resources.Voice.VoiceBaseLists<MessageService.RestAPI.Objects.Voice.Recording>
    {
        public RecordingLists(string callId, string legId)
            : base("recordings", new MessageService.RestAPI.Objects.Voice.RecordingList { CallId = callId, LegId = legId })
        { }

        public RecordingLists(MessageService.RestAPI.Objects.Voice.RecordingList list) : base("recordings", list) { }

        public override string Uri
        {
            get
            {
                return String.Format("calls/{0}/legs/{1}/{2}", ((MessageService.RestAPI.Objects.Voice.RecordingList)Object).CallId, ((MessageService.RestAPI.Objects.Voice.RecordingList)Object).LegId, Name);
            }
        }
    }
}
