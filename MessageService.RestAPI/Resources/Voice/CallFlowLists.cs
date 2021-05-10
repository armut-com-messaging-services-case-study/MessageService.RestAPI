namespace MessageService.RestAPI.Resources.Voice
{
    public class CallFlowLists : VoiceBaseLists<MessageService.RestAPI.Objects.Voice.CallFlow>
    {
        public CallFlowLists()
            : base("call-flows", new MessageService.RestAPI.Objects.Voice.CallFlowList())
        { }

        public CallFlowLists(MessageService.RestAPI.Objects.Voice.CallFlowList list) : base("call-flows", list) { }
    }
}