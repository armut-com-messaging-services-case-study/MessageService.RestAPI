namespace MessageService.RestAPI.Resources
{
    public sealed class VoiceMessages : Resource
    {
        public VoiceMessages(MessageService.RestAPI.Objects.VoiceMessage voiceMessage) :
            base("voicemessages", voiceMessage)
        {
            Object = voiceMessage;
        }
    }
}
