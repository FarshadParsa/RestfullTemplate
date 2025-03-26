using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Base.Models.Exceptions
{
    public class NotFoundApiException : HttpResponseException
    {
        public NotFoundApiException(string message = "No entity found for the request")
            : base(message)
        { }

        public override int Status => 404;
    }
}
