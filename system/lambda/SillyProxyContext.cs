using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AWSNetCore
{
    public class SillyProxyContext : ISillyContext
    {

        public string Path { get; private set; }
        public SillyProxyRequest OriginalRequest { get; private set; }

        public SillyProxyContext(SillyProxyRequest request)
        {
            OriginalRequest = request;

            if (request == null)
            {
                return;
            }

            _get = request.queryStringParameters;
            // POST is either name=value pairs or json, depending on the header's content-type value
            // x-www-form-urlencoded = name=value pairs
            // application/json = json

            Path = request.path;

            //ParsePath(request.path);
        }

        private IDictionary<string, object> _get;

        public object GET(string name)
        {
            return(null);
        }

        //private IDictionary<string, object> _post;

        public object POST(string name)
        {
            return(null);
        }
        
    }
}