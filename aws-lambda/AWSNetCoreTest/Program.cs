using Xunit;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Lambda.TestUtilities;

namespace AWSNetCoreLambda.Tests
{
    public class FunctionTest
    {
        IAmazonDynamoDB DDBClient { get; }

        public FunctionTest()
        {
            this.DDBClient = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        }

        [Fact]
        public async void TetGetMethod()
        {
            TestLambdaContext context;

            ServerlessHelloWorld functions = new ServerlessHelloWorld(this.DDBClient);

            context = new TestLambdaContext();
            var response = await functions.Get(context);

            Assert.Equal("{\"language\":\"english\",\"greeting\":\"Hello World\"}", response);
        }
    }
}
