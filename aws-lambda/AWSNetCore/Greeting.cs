using System;

using Amazon.DynamoDBv2.DataModel;

namespace AWSNetCoreLambda
{
    [DynamoDBTableAttribute("Greetings")]
    public class Greeting
    {
        [DynamoDBHashKeyAttribute]
        public string language { get; set; }
        
        [DynamoDBPropertyAttribute]
        public string greeting { get; set; }
    }
}