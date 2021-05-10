using MessageService.RestAPI;
using MessageService.RestAPI.Exceptions;
using MessageService.RestAPI.Net.ProxyConfigurationInjector;
using MessageService.RestAPI.Objects;
using System;

namespace Examples.Message
{
    class CreateMessage
    {
        const string YourAccessKey = "YOUR_ACCESS_KEY"; // your access key here.
        const long Msisdn = 5178173252; // your phone number here.

        static void Main(string[] args)
        {
            IProxyConfigurationInjector proxyConfigurationInjector = null; // for no web proxies || web proxies not requiring authentication

            Client client = Client.CreateDefault(YourAccessKey, proxyConfigurationInjector);

            try
            {
                MessageService.RestAPI.Objects.Message message = client.SendMessage("MessageService", "Tjirp tjirp", new[] { Msisdn });
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
