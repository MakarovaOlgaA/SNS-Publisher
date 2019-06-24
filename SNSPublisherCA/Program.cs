namespace SNSPublisherCA
{
    using Amazon;
    using Amazon.SimpleNotificationService;
    using Amazon.SimpleNotificationService.Model;
    using SNSPublisher;
    using System;
    using System.Configuration;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            SNSAsync().Wait();
            Console.ReadLine();
        }

        static async Task SNSAsync()
        {
            var topicArn = ConfigurationManager.AppSettings["DemoTopicArn"];
            var snsClient = new AmazonSimpleNotificationServiceClient(ConfigurationManager.AppSettings["AccessId"], ConfigurationManager.AppSettings["SecretKey"], RegionEndpoint.USEast1);

            var publisher = new SNSPublisher();
            PublishResponse response = await publisher.SendMessage(snsClient, topicArn, "MESSAGE");
            Console.WriteLine(response.MessageId);

            MessageAttributes messageAttributes = new MessageAttributes();
            messageAttributes.Add("provider_type", "LOA");
            response = await publisher.SendMessage(snsClient, topicArn, "MESSAGE WITH MATCHING ATTRIBUTES", messageAttributes);
            Console.WriteLine(response.MessageId);

            messageAttributes.Add("provider_type", "MR");
            response = await publisher.SendMessage(snsClient, topicArn, "MESSAGE WITH NON-MATCHING ATTRIBUTES", messageAttributes);
            Console.WriteLine(response.MessageId);
        }

    }
}
