namespace MessageService.RestAPI.Resources.Voice
{
    public class CallLists : VoiceBaseLists<MessageService.RestAPI.Objects.Voice.Call>
    {
        public CallLists()
            : base("calls", new MessageService.RestAPI.Objects.Voice.CallList())
        { }

        public CallLists(Objects.Voice.CallList callList) : base("calls", callList) { }
    }
}