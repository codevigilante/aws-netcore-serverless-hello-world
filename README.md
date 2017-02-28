# AWS .NET Core (1.0) Serverless "Hello World"

This little app is an experiment to play around with AWS "serverless" infrastructure using the fairly new .NET Core and C#.  

See it in action @ [awsnetcore.com](http://awsnetcore.com)

# The Plan

1. Design a simple, static HTML page that uses jQuery to call the API method and populate the page
1. [Deploy the static site to an AWS S3 bucket and configure it as a static website.](http://docs.aws.amazon.com/AmazonS3/latest/dev/website-hosting-custom-domain-walkthrough.html)
1. Use AWS Route 53 to point a custom domain at the S3 bucket.
1. Build an API gateway call that will hookup to a mock endpoint and return json with a "Hello World" greeting [start here](http://docs.aws.amazon.com/apigateway/latest/developerguide/api-gateway-create-resource-and-methods.html)
    1. NOTE: CORS needs to be enabled for the API method or calling from any other domain will successfully fail (not a typo).

# Abandoned

These things were abandoned, although the code is still in this project and functional. I ran into some latency problems using Lambda and execessive down times. Perhaps they're still ironing some issues, although the service only appeared to be down for the region I was using (US-east-1). Perhaps in the near future I'll tie this all back together, but for now, I'll stick with a lightweight EC2 instance for all API needs (coming soon).

1. Create a DynamoDB table called 'Greetings' and a partition key called 'greeting' and add one row with the text: "Hello World"
1. Write a C# function, targeting Lambda, that returns the row created in DynamoDB
1. Wire an API Gateway resource:GET to the Lambda function

# Constraints

* All code developed using Microsoft's cross platform IDE, Visual Code (mostly on Mac)
* Use dotnet command line tools