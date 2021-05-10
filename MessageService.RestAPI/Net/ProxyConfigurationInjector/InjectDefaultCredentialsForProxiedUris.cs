using System.Net;

namespace MessageService.RestAPI.Net.ProxyConfigurationInjector
{
    public class InjectDefaultCredentialsForProxiedUris : InjectCredentialsForProxiedUris
    {
        public InjectDefaultCredentialsForProxiedUris() : base(CredentialCache.DefaultCredentials)
        {
        }
    }
}
