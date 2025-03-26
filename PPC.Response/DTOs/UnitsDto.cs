using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace WebApi.Response.DTOs
{
    public class UnitsDTO
    {

        [JsonProperty("UnitID")]
        public int UnitID { get; set; }

        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("UnitLatinName")]
        public string UnitLatinName { get; set; }

        [JsonProperty("Abbreviation")]
        public string Abbreviation { get; set; }

    }
}
