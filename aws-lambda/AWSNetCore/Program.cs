using System;
using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization;

[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSNetCoreLambda
{
    public class ServerlessHelloWorld
    {
        public ServerlessHelloWorld()
        {

        }

        // Lambda Signature: AWSNetCore::AWSNetCoreLambda.ServerlessHelloWorld::Get
        public string Get (ILambdaContext context)
        {
            context.Logger.LogLine("Get Request");

            Greeting greeting = new Greeting();

            greeting.greeting = "Hello World";

            return JsonConvert.SerializeObject(greeting);
        }

        // Lambda Signature: AWSNetCore::AWSNetCoreLambda.ServerlessHelloWorld::Get
        /*public APIGatewayProxyResponse Get (APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request");

            Greeting greeting = new Greeting();

            greeting.greeting = "Hello World";

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(greeting),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" }, { "Access-Control-Allow-Origin", "*" } }
            };

            return response;
        }*/
    }
}
