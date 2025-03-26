using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Response.DTOs
{
    public class EmployeeDto
    {
        [JsonProperty("EMPLOYEEID")]
        public string EMPLOYEEID { get; set; }

        //[JsonProperty("EMPLOYEENO")]
        //public double EMP_NO { get; set; }

        //[JsonProperty("LE_NO")]
        //public short LE_NO { get; set; }


        //[JsonProperty("PERS_NO")]
        //public double PERS_NO { get; set; }

        [JsonProperty("NAME")]
        public string NAME { get; set; }

        [JsonProperty("FAMILY")]
        public string FAMILY { get; set; }

        [JsonProperty("PASSWORD")]
        public string PASSWORD { get; set; }
    }
}
