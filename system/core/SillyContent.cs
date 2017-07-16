using System;

namespace AWSNetCore
{
    public class SillyContent : ISillyContent
    {
        public SillyContentType ContentType { get; set; }
        public string Content { get; set; }

        public SillyContent()
        {
            ContentType = SillyContentType.Html;
            Content = string.Empty;
        }  
    }
}