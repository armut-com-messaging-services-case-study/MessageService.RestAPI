using Newtonsoft.Json;

namespace MessageService.RestAPI.Resources.Conversations
{
    public class ConversationStart : Resource
    {
        public MessageService.RestAPI.Objects.Conversations.ConversationStartRequest Request { get; protected set; }

        public ConversationStart(MessageService.RestAPI.Objects.Conversations.ConversationStartRequest request)
            : base("conversations", new MessageService.RestAPI.Objects.Conversations.Conversation())
        {
            Request = request;
        }

        public override string Uri
        {
            get { return string.Format("{0}/start", Name); }
        }

        public override string Serialize()
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(Request, settings);
        }
        public override string BaseUrl
        {
            get { return Conversations.ConverstationsBaseUrl; }
        }
    }
}