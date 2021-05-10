using Newtonsoft.Json;
using System;

namespace MessageService.RestAPI.Resources.Conversations
{
    public class MessageSend : Resource
    {
        public MessageService.RestAPI.Objects.Conversations.ConversationMessageSendRequest Request { get; protected set; }

        public MessageSend(MessageService.RestAPI.Objects.Conversations.ConversationMessageSendRequest request)
            : base("messages", new MessageService.RestAPI.Objects.Conversations.ConversationMessage())
        {
            Request = request;
        }

        public override string Serialize()
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(Request, settings);
        }

        public override string Uri
        {
            get { return String.Format("conversations/{0}/{1}", Request.ConversationId, Name); }
        }

        public override string BaseUrl
        {
            get { return Conversations.ConverstationsBaseUrl; }
        }
    }
}