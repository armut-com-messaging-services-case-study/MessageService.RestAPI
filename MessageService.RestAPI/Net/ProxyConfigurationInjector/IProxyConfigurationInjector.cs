using System;
using System.Net;

namespace MessageService.RestAPI.Net.ProxyConfigurationInjector
{
    public interface IProxyConfigurationInjector
    {
        IWebProxy InjectProxyConfiguration(IWebProxy webProxy, Uri uri);
    }
}