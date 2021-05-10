namespace MessageService.RestAPI.Objects.Conversations
{
    public class ConversationMessageList : BaseList<ConversationMessage>

    {
        public string ConversationId { get; set; }
    }
}