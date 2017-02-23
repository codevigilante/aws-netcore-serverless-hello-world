using System.Threading.Tasks;

using Newtonsoft.Json;

using Amazon.Lambda.Core;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSNetCoreLambda
{
    public class ServerlessHelloWorld
    {
        const string GREETINGS_TABLE_NAME = "Greetings";
        private IDynamoDBContext dbContext { get; set; }

        public ServerlessHelloWorld()
        {
            AWSConfigsDynamoDB.Context.TypeMappings[typeof(Greeting)] = new Amazon.Util.TypeMapping(typeof(Greeting), GREETINGS_TABLE_NAME);

            var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };
            
            this.dbContext = new DynamoDBContext(new AmazonDynamoDBClient(), config);
        }

        // Constructor used for testing
        public ServerlessHelloWorld(IAmazonDynamoDB client)
        {
            AWSConfigsDynamoDB.Context.TypeMappings[typeof(Greeting)] = new Amazon.Util.TypeMapping(typeof(Greeting), GREETINGS_TABLE_NAME);

            var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };

            this.dbContext = new DynamoDBContext(client, config);
        }

        // Lambda Signature: AWSNetCore::AWSNetCoreLambda.ServerlessHelloWorld::Get
        public async Task<string> Get (ILambdaContext context)
        {
            context.Logger.LogLine("Get Greeting Request");

            var greeting = await dbContext.LoadAsync<Greeting>("english");

            context.Logger.LogLine($"Found greeting: {greeting != null}");

            if (greeting == null)
            {
                return (string.Empty);
            }

            return JsonConvert.SerializeObject(greeting);
        }
    }
}
