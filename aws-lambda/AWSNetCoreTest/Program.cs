using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using AWSNetCoreLambda;

namespace AWSNetCoreLambda.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TetGetMethod()
        {
            TestLambdaContext context;

            ServerlessHelloWorld functions = new ServerlessHelloWorld();

            context = new TestLambdaContext();
            var response = functions.Get(context);

            Assert.Equal("{\"greeting\":\"Hello World\"}", response);
        }
    }
}
