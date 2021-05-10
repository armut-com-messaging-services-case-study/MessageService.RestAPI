namespace MessageService.RestAPI.Objects
{
    public interface IIdentifiable<out T>
    {
        T Id { get; }
    }
}
