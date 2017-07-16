using System;
using System.Dynamic;
using Newtonsoft.Json;

namespace AWSNetCore
{
    public class SillyProxyRequest
    {
        public string resource { get; set; }
        public string path { get; set; }
        public string httpMethod { get; set; }
        public dynamic queryStringParameters { get; set; }
        public dynamic headers { get; set; }
        public string body { get; set; }

        public SillyProxyRequest()
        {
            queryStringParameters = new ExpandoObject();
            headers = new ExpandoObject();
        }
    }
}