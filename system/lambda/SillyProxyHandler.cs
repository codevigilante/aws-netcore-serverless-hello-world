using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon;

[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSNetCore
{
    public abstract class SillyProxyHandler : SillyHandler
    {
        private string IndexKey = "Index";
        private string RootKey = "/";

        public SillyProxyHandler()
        {
        }

        protected abstract AbstractSillyController BuildControllerTree();

        //********************************************************************
        // Lambda signature: aws-netcore-serverless-hello-world::AWSNetCore.<MyLambdaHandlerDerivedClass>::Handle
        //********************************************************************
        [Amazon.Lambda.Core.LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public virtual SillyProxyResponse Handle(SillyProxyRequest input, ILambdaContext lambdaContext)
        {
            try
            {
                if (SillyRouteMap.RouteCount() == 0)
                {
                    throw new SillyException(SillyHttpStatusCode.NotImplemented, "This site isn't configured for prime time just yet. Please try again later");
                }

                if (input == null)
                {
                    throw new SillyException(SillyHttpStatusCode.ServerError, "Request aborted upon delivery.");
                }
            
                ISillyContext sillyContext = CreateContext(input);                
                ISillyContent sillyContent = Dispatch(input.path, sillyContext);

                if (sillyContent == null)
                {
                    throw new SillyException(SillyHttpStatusCode.NotFound, "The path " + input.path + " does not exist.");
                }
                
                lambdaContext.Logger.LogLine("Request completed for path '" + input.path + "'");

                SillyProxyResponse response = new SillyProxyResponse();
                response.body = sillyContent.Content;
                //response.headers.ContentType = sillyContext.ContentType;

                return(response);
            }
            catch (SillyException sillyEx)
            {
                return(buildErrorResponse(sillyEx));
            }
            catch (Exception Ex)
            {
                return(buildErrorResponse(SillyHttpStatusCode.ServerError, Ex.Message));
            }
        }

        protected virtual ISillyContent Dispatch(string path, ISillyContext context)
        {
            /*if (String.IsNullOrEmpty(path))
            {
                throw new SillyException(SillyHttpStatusCode.BadRequest, "Requested path '" + path + "' does not exist.");
            }

            string[] segments = ParsePath(path, false);
            ISillyTreeNode<AbstractSillyController> controller = Root;
            object[] parameters = new object[1] { context };
            int index = 0;

            // when the lowest controller is reached, figure out which method matches the remaining segments

            if(segments != null &&
               segments.Length > 0)
            {
                bool controllerFound = false;

                for(; index < segments.Length; ++index)
                {
                    string segment = segments[index];

                    if (!controllerFound)
                    {
                        ISillyTreeNode<AbstractSillyController> node = controller.GetChild(segment);

                        if(node != null)
                        {
                            controller = node;
                        }
                        else
                        {
                            controllerFound = true;
                        }
                    }
                    else
                    {
                        parameters.Append(segment);
                    }
                }
            }

            IEnumerable<MethodInfo> methods = QueryMethods(controller.Value.GetType().GetMethods(), IndexKey, parameters.Length);

            if (methods == null ||
                methods.Count() == 0)
            {
                throw new SillyException(SillyHttpStatusCode.NotFound, "The path " + path + " does not exist.");
            }

            try
            {
                ISillyContent content = methods.ElementAt(0).Invoke(controller.Value, (parameters.Length == 0) ? null : parameters) as ISillyContent;

                return(content);
            }
            catch(Exception ex)
            {
                throw new SillyException(SillyHttpStatusCode.NotFound, ex.Message);
            }

            */
            return(null);
        }

        protected virtual ISillyContext CreateContext(SillyProxyRequest request)
        {
            return (new SillyProxyContext(request));
        }

        protected string[] ParsePath(string path, bool keepSlashes = true)
        {
            if (path == null ||
                String.IsNullOrEmpty(path))
            {
                return(null);
            }

            string pattern = keepSlashes ? @"(\/)" : @"\/";

            string[] matches = Regex.Split(path, pattern, RegexOptions.IgnoreCase);

            return(matches);
        }

        private IEnumerable<MethodInfo> QueryMethods(MethodInfo[] methodInfos, string methodKey, int varCount)
        {
            IEnumerable<MethodInfo> methods = null;
            
            if (!String.IsNullOrEmpty(methodKey))
            {
                methods = methodInfos.Where
                (
                    m => String.Compare(m.Name, methodKey, true) == 0 &&
                         m.ReturnType.IsAssignableFrom(typeof(ISillyContent)) &&
                         m.GetParameters().Length == varCount &&
                         m.GetParameters()[0].ParameterType == typeof(ISillyContext)
                );
            }

            return(methods);
        }

        private SillyProxyResponse buildErrorResponse(SillyException ex)
        {
            return(buildErrorResponse(ex.StatusCode, ex.Message));
        }

        private SillyProxyResponse buildErrorResponse(SillyHttpStatusCode statusCode, string details)
        {
            SillyProxyResponse errorResponse = new SillyProxyResponse(statusCode);

            errorResponse.body = "<h1>Server ERROR</h1><h3>" + errorResponse.StatusCodeToString() + "</h3>";
            errorResponse.body += "<p>" + details + "</p>";

            return(errorResponse);
        }
    }
}
