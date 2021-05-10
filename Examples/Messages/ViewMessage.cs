using MessageService.RestAPI;
using MessageService.RestAPI.Exceptions;
using MessageService.RestAPI.Net.ProxyConfigurationInjector;
using MessageService.RestAPI.Objects;
using System;

namespace Examples.Message
{
    class ViewMessage
    {
        const string YourAccessKey = "YOUR_ACCESS_KEY"; // your access key here.
        const string MessageId = "ad15c8c0153a194a59a17e2c61578856"; // ID of message you sent before. When not found, you will not get a http StatusCode 404, but an exception `code: 20 description: 'message not found' parameter: ''`

        static void Main(string[] args)
        {
            IProxyConfigurationInjector proxyConfigurationInjector = null; // for no web proxies, or web proxies not requiring authentication

            Client client = Client.CreateDefault(YourAccessKey, proxyConfigurationInjector);

            try
            {
                MessageService.RestAPI.Objects.Message message = client.ViewMessage(MessageId);
                Console.WriteLine("{0}", message);
            }
            catch (ErrorException e)
            {
                // Either the request fails with error descriptions from the endpoint.
                if (e.HasErrors)
                {
                    foreach (Error error in e.Errors)
                    {
                        Console.WriteLine("code: {0} description: '{1}' parameter: '{2}'", error.Code, error.Description, error.Parameter);
                    }
                }
                // or fails without error information from the endpoint, in which case the reason contains a 'best effort' description.
                if (e.HasReason)
                {
                    Console.WriteLine(e.Reason);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
