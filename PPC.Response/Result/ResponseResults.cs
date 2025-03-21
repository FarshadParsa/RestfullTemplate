using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PPC.Response.Result
{
    public partial class ResponseResults<T>
    {


        public int Code { get; set; } = 0;
        public string Message { get; set; } = string.Empty; 

        public int? Results { get; set; }

        public T Data { get;  set; }

    }
}
