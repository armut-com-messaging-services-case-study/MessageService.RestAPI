namespace MessageService.RestAPI.Resources
{
    public class ContactLists : BaseLists<Objects.Contact>
    {
        public ContactLists()
            : base("contacts", new Objects.ContactList())
        {
            //
        }
    }
}
