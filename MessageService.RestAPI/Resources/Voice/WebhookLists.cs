namespace MessageService.RestAPI.Resources.Voice
{
    public class WebhookLists : VoiceBaseLists<MessageService.RestAPI.Objects.Voice.Webhook>
    {
        public WebhookLists()
            : base("webhooks", new MessageService.RestAPI.Objects.Voice.WebhookList())
        { }

        public WebhookLists(Objects.Voice.WebhookList webhookList) : base("webhooks", webhookList) { }
    }
}
