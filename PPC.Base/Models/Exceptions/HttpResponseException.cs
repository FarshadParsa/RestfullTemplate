using System;

namespace WebApi.Base.Models.Exceptions
{
    public abstract class HttpResponseException : Exception
    {
        public HttpResponseException(string message) : base(message) { }
        public abstract int Status { get; }
    }
}
