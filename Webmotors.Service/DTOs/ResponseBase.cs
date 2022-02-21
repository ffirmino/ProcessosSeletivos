using System;

namespace Webmotors.Service.DTOs
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public ResponseBase()
        {
            Success = true;
        }
    }

    public class ResponseBase<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}
