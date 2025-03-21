using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class InvProductionRawMaterialsDTO
    {

        #region Base properties
        [JsonProperty("InvProductionRawMaterialID")]
        public int InvProductionRawMaterialID { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("RawMaterialsDeliveredToProductionID")]
        public int RawMaterialsDeliveredToProductionID { get; set; }

        [JsonProperty("Weight")]
        public decimal Weight { get; set; }

        [JsonProperty("EntryDate")]
        public string EntryDate { get; set; }

        [JsonProperty("EntryTime")]
        public string EntryTime { get; set; }

        [JsonProperty("ReceivingUserID")]
        public int ReceivingUserID { get; set; }

        [JsonProperty("InsUserID")]
        public int InsUserID { get; set; }

        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        [JsonProperty("InsSysTime")]
        public DateTime? InsSysTime { get; set; }
        #endregion Base properties

    }
}
