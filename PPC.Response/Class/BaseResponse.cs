using WebApi.Response.Result;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApi.Response.Class
{
    public partial class BaseResponse<T>
    {


        [JsonPropertyName(nameof(Payload))]
        public ResponseResults<T> Payload { get; set; }//PPCApi
        public BaseResponse()
        {
            Payload = new ResponseResults<T>();

        }
    }
}
