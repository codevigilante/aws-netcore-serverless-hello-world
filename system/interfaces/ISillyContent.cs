using System;

namespace AWSNetCore
{
    public enum SillyContentType { Html, Json }

    public interface ISillyContent
    {
        SillyContentType ContentType { get; set; }
        string Content { get; set; }        
    }
}