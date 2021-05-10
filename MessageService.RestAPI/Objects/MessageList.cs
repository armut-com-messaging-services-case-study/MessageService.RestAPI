namespace MessageService.RestAPI.Objects
{
    public class MessageList : BaseList<Message>
    {
        public string Status { get; set; }
    }
}
