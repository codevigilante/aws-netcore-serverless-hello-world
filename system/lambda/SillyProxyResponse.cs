using System;
using Newtonsoft.Json;

namespace AWSNetCore
{
    public enum SillyHttpStatusCode : int { Success = 200, BadRequest = 400, NotFound = 404, ServerError = 500, NotImplemented = 501 }

    public class SillyProxyResponse
    {
        public class Headers
        {
            [JsonProperty("content-type")]
            public string ContentType { get; set; }
        }

        public SillyProxyResponse(SillyHttpStatusCode status = SillyHttpStatusCode.Success)
        {
            headers = new Headers();
            isBase64Encoded = false;
            statusCode = (int)status;
            headers.ContentType = "text/html";
            body = string.Empty;
        }
        public bool isBase64Encoded { get; set; }
        public int statusCode { get; set; }
        public string body { get; set; }
        public Headers headers { get; set; }

        public string StatusCodeToString()
        {
            string str = statusCode + string.Empty;
            
            switch(statusCode)
            {
                case (int)SillyHttpStatusCode.Success:
                    return(str + ": Success");
                case (int)SillyHttpStatusCode.BadRequest:
                    return(str + ": Bad Request");
                case (int)SillyHttpStatusCode.NotFound:
                    return(str + ": Not Found");
                case (int)SillyHttpStatusCode.NotImplemented:
                    return(str + ": Not Implemented");
                case (int)SillyHttpStatusCode.ServerError:
                    return(str + ": Server Error");
                default:
                    return(str + ": What?");
            }
        }
    }
}