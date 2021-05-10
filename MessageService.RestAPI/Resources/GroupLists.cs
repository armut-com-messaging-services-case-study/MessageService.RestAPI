namespace MessageService.RestAPI.Resources
{
    public class GroupLists : BaseLists<Objects.Group>
    {
        public GroupLists()
            : base("groups", new Objects.GroupList())
        {
            //
        }
    }
}
