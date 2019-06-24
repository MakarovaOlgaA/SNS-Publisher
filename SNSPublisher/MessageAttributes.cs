using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;

namespace SNSPublisher
{
    public class MessageAttributes
    {
        public Dictionary<String, MessageAttributeValue> Attributes { get; private set; }

        public MessageAttributes()
        {
            Attributes = new Dictionary<string, MessageAttributeValue>();
        }

        public void Add(String attributeName, String attributeValue)
        {
            Attributes[attributeName] = new MessageAttributeValue
            {
                DataType = "String",
                StringValue = attributeValue
            };
        }

        public void Add(String attributeName, float attributeValue)
        {
            Attributes[attributeName] = new MessageAttributeValue
            {
                DataType = "Number",
                StringValue = attributeValue.ToString()
            };
        }

        public void Add(String attributeName, int attributeValue)
        {
            Attributes[attributeName] = new MessageAttributeValue
            {
                DataType = "Number",
                StringValue = attributeValue.ToString()
            };
        }

        public void Add(String attributeName, List<Object> attributeValue)
        {
            String valueString = "[" + String.Join(", ", attributeValue.ToArray()) + "]";
            Attributes[attributeName] = new MessageAttributeValue
            {
                DataType = "String.Array",
                StringValue = valueString
            };
        }
    }
}
