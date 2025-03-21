using PPC.Response.Result;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PPC.Response.Class
{
    public partial class BaseResponse<T>
    {


        [JsonPropertyName(nameof(PPCAPI))]
      // [JsonProperty(PropertyName = nameof(PPCAPI))]
        public ResponseResults<T> PPCAPI { get; set; }
        public BaseResponse()
        {
            PPCAPI = new ResponseResults<T>();

        }
    }
}
