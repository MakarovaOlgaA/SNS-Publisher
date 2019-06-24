namespace SNSPublisher
{
    using Amazon.SimpleNotificationService;
    using Amazon.SimpleNotificationService.Model;
    using System.Threading.Tasks;

    public class SNSPublisher
    {
        public async Task<PublishResponse> SendMessage(AmazonSimpleNotificationServiceClient client, string topicArn, string message)
        {
            var request = new PublishRequest(topicArn, message);
            return await client.PublishAsync(request);
        }

        public async Task<PublishResponse> SendMessage(AmazonSimpleNotificationServiceClient client, string topicArn, string message,
            MessageAttributes messageAttributes)
        {
            PublishRequest request = new PublishRequest
            {
                TopicArn = topicArn,
                MessageAttributes = messageAttributes.Attributes,
                Message = message
            };
            return await client.PublishAsync(request);
        }
    }
}
