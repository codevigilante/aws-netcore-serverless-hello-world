# AWS .NET Core (1.0) Serverless "Hello World"

So, here we are. This little app is an experiment to play around with AWS serverless infrastructure, Lambda in particular, using the fairly new .NET Core and C#.  

# The Plan

* Create a DynamoDB table that contains two rows: "Hello" and "World"
* Write a C# function, targeting Lambda, that returns those two rows
* Wire an API Gateway method called 'GetHelloWorld' to the Lambda function
* Design a simple, static HTML page that uses jQuery to call the API method and populate the page
* Deploy to the domain, something like, aws-netcore-serverless-hello-world.com, and hook it up to the static content via Route 53

# Constraints

* All code developed using Microsofts cross platform IDE, Code
* Split development between Windows and Mac, to exercise cross compatability or whatever
