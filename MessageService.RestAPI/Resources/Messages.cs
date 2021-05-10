namespace MessageService.RestAPI.Resources
{
    public sealed class Messages : Resource
    {
        public Messages(MessageService.RestAPI.Objects.Message message)
             : base("messages", message)
        {
        }
    }
}
