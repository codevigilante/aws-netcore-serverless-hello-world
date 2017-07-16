namespace AWSNetCore
{
    public class AWSNetCoreLambdaHandler : SillyProxyHandler
    {
        public AWSNetCoreLambdaHandler()
            : base()
        {
        }

        protected override AbstractSillyController BuildControllerTree()
        {
            return(null);
        }
    }
}