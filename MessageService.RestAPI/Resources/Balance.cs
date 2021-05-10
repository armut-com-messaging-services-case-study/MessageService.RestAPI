namespace MessageService.RestAPI.Resources
{
    class Balance : Resource
    {
        public Balance()
            : base("balance", new Objects.Balance())
        {
        }
    }
}
