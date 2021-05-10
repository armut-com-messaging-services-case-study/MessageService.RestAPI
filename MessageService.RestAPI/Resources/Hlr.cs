namespace MessageService.RestAPI.Resources
{
    sealed class Hlr : Resource
    {
        public Hlr(Objects.Hlr hlr)
            : base("hlr", hlr)
        {
        }
    }
}
