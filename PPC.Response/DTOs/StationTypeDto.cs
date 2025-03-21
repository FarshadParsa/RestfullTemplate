using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Response.DTOs
{
    public class StationTypeDTO
    {

        [JsonProperty("StationTypeID")]
        public int StationTypeID { get; set; }

        [JsonProperty("StationTypeName")]
        public string StationTypeName { get; set; }=string.Empty;

        [JsonProperty("StationTypeLatinName")]
        public string StationTypeLatinName { get; set; } = string.Empty;
    }
}
