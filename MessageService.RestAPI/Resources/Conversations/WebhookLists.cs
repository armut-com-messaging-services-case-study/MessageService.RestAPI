namespace MessageService.RestAPI.Resources.Conversations
{
    public class WebhookLists : MessageService.RestAPI.Resources.BaseLists<MessageService.RestAPI.Objects.Conversations.ConversationWebhook>
    {
        public WebhookLists()
            : base("webhooks", new RestAPI.Objects.Conversations.ConversationWebhookList())
        { }

        public override string BaseUrl
        {
            get { return ConverstationsBaseUrl; }
        }
    }
}