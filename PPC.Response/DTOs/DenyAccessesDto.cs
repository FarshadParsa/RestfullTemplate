using Newtonsoft.Json;
using System;

namespace WebApi.Response.DTOs
{
    public class DenyAccessesDTO
    {

        #region Base properties and methods(generated by  CodeGenerator)
        [JsonProperty("DenyAccessID")]
        public int DenyAccessID { get; set; }

        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("StationID")]
        public int StationID { get; set; }

        [JsonProperty("MenuGroupID")]
        public byte MenuGroupID { get; set; }

        [JsonProperty("MenuName")]
        public string MenuName { get; set; }

        [JsonProperty("MenuID")]
        public Int16 MenuID { get; set; }

        [JsonProperty("Caption")]
        public string Caption { get; set; }

        [JsonProperty("CaptionPath")]
        public string CaptionPath { get; set; }

        [JsonProperty("State")]
        public decimal State { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)
    }
}