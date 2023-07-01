using System;
using System.Net;
using System.Runtime.Serialization;

namespace ImageStreaming.Shared.Persistence.Common.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        public HttpStatusCode Code { get; set; }

        protected BaseException(HttpStatusCode code, string message, Exception innerException = default)
            : base(message, innerException)
        {
            Code = code;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}

