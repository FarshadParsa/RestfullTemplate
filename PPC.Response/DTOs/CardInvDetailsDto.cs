using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class CardInvDetailsDTO
    {

        #region Base properties
        [JsonProperty("ID")]
        public long ID { get; set; }

        [JsonProperty("InvTypeID")]
        public char InvTypeID { get; set; }

        [JsonProperty("Year")]
        public short Year { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("EntryDate")]
        public string EntryDate { get; set; }

        [JsonProperty("EntryTime")]
        public string EntryTime { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("CardTypeVal")]
        public char CardTypeVal { get; set; }

        [JsonProperty("IsEntry")]
        public bool IsEntry { get; set; }

        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [JsonProperty("InsUserID")]
        public int InsUserID { get; set; }

        [JsonProperty("InvRawMaterialID")]
        public int? InvRawMaterialID { get; set; }

        [JsonProperty("RawMaterialsDeliveredToProductionDetailID")]
        public int? RawMaterialsDeliveredToProductionDetailID { get; set; }

        [JsonProperty("InvProductionRawMaterialID")]
        public int? InvProductionRawMaterialID { get; set; }

        [JsonProperty("DataDosingDetailID")]
        public int? DataDosingDetailID { get; set; }
        #endregion Base properties

    }
}