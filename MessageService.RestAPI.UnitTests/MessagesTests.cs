using MessageService.RestAPI.Objects;
using MessageService.RestAPI.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace MessageService.RestAPI.UnitTests
{
    [TestClass]
    public class MessagesTests
    {
        [TestMethod]
        public void DeserializeAndSerialize()
        {
            const string CreateMessageResponseTemplate = @"{
  'id':'e7028180453e8a69d318686b17179500',
  'href':'https:\/\/localhost\/messages\/e7028180453e8a69d318686b17179500',
  'direction':'mt',
  'type':'sms',
  'originator':'$ORIGINATOR',
  'body':'Welcome to localhost',
  'reference':null,
  'validity':null,
  'gateway':56,
  'typeDetails':{
    
  },
  'datacoding':'plain',
  'mclass':1,
  'scheduledDatetime':null,
  'createdDatetime':'2014-08-11T11:18:53+00:00',
  'recipients':{
    'totalCount':1,
    'totalSentCount':1,
    'totalDeliveredCount':0,
    'totalDeliveryFailedCount':0,
    'items':[
      {
        'recipient':31612345678,
        'status':'sent',
        'statusDatetime':'2014-08-11T11:18:53+00:00'
      }
    ]
  }
}";
            Recipients recipients = new Recipients();
            Message message = new Message("", "", recipients);
            Messages messages = new Messages(message);

            messages.Deserialize(CreateMessageResponseTemplate.Replace("$ORIGINATOR", "MessageService"));
            JsonConvert.DeserializeObject<Message>(messages.Object.ToString());

            messages.Deserialize(CreateMessageResponseTemplate.Replace("$ORIGINATOR", "3112345678"));
            JsonConvert.DeserializeObject<Message>(messages.Object.ToString());

            messages.Deserialize(CreateMessageResponseTemplate.Replace("$ORIGINATOR", "+3112345678"));
            JsonConvert.DeserializeObject<Message>(messages.Object.ToString());
        }

        [TestMethod]
        public void ListMessages()
        {
            var restClient = MockRestClient
                .ThatReturns(filename: "ListMessages.json")
                .FromEndpoint("GET", "messages?limit=20&offset=0")
                .Get();
            var client = Client.Create(restClient.Object);

            var messages = client.ListMessages();
            restClient.Verify();

            Assert.AreEqual(1, messages.Items.Count);
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual("YourName", messages.Items[0].Originator);
        }

        [TestMethod]
        public void ListScheduledMessages()
        {
            var restClient = MockRestClient
                .ThatReturns(filename: "ListMessages.json")
                .FromEndpoint("GET", "messages?limit=20&offset=0&status=scheduled")
                .Get();
            var client = Client.Create(restClient.Object);

            client.ListMessages("scheduled");
            restClient.Verify();
        }

        [TestMethod]
        public void DeserializeRecipientsAsMsisdnsArray()
        {
            var recipients = new Recipients();
            recipients.AddRecipient(31612345678);

            var message = new Message("Sms", "Welcome to localhost", recipients);
            var messages = new Messages(message);

            string serializedMessage = messages.Serialize();

            messages.Deserialize(serializedMessage);
        }

        [TestMethod]
        public void OriginatorFormat()
        {
            var recipients = new Recipients();
            recipients.AddRecipient(31612345678);

            var message = new Message("Provider", "This is a message with less or equal than 11 alphanumeric characters.", recipients);
            Assert.AreEqual("Provider", message.Originator);

            message = new Message("321321321321", "This is a message with numeric characters.", recipients);
            Assert.AreEqual("3197001234567890", message.Originator);

            message = new Message("Hell0 Dünya", "This is a message with alphanumeric characters and whitespaces and less or equal than 11 characters.", recipients);
            Assert.AreEqual("Or igna t0r", message.Originator);

            try
            {
                message = new Message("Pr0 vider ", "This is a message from an invalid provider with trailing whitespace.", recipients);
                Assert.Fail("Expected an exception, because the originator contains trailing whitespace!");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual("Provider can only contain numeric or whitespace separated alphanumeric characters.", e.Message);
            }

            try
            {
                message = new Message(" Provider", "This is a message from an inavlid originator with leading whitespace.", recipients);
                Assert.Fail("Expected an exception, because the originator contains leading whitespace!");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual("Provider can only contain numeric or whitespace separated alphanumeric characters.", e.Message);
            }

            try
            {
                message = new Message("ProviderXL", "This is a message from an invalid originator with more than 11 alphanumeric characters.", recipients);
                Assert.Fail("Expected an exception, because the originator has more than 11 alphanumeric characters.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual("Alphanumeric provider is limited to 11 characters.", e.Message);
            }
        }

        [TestMethod]
        public void ReportUrl()
        {
            var recipients = new Recipients();
            recipients.AddRecipient(31612345678);
            var optionalArguments = new MessageOptionalArguments
            {
                ReportUrl = "https://localhost:8080",
            };

            var message = new Message("Provider", "Body", recipients, optionalArguments);

            Assert.AreEqual("https://localhost:8080", message.ReportUrl);
        }
    }
}
