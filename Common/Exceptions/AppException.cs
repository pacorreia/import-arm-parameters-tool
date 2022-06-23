using System;
using System.Net;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class AppRuntimeException : SystemException
    {
        public HttpStatusCode Status { get; private set; }

        public AppRuntimeException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }

        protected AppRuntimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
