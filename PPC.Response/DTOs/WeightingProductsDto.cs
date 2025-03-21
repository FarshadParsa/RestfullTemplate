using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Response.DTOs
{
    public class WeightingProductsDTO
    {

        #region Base properties
        [JsonProperty("WeightingProductID")]
        public int WeightingProductID { get; set; }

        [JsonProperty("ProductionPlanPatilID")]
        public int? ProductionPlanPatilID { get; set; }

        [JsonProperty("InvProductID")]
        public int? InvProductID { get; set; }


        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("EntryWeight")]
        public decimal EntryWeight { get; set; }

        [JsonProperty("PackagedWeight")]
        public decimal PackagedWeight { get; set; }

        [JsonProperty("Waste")]
        public decimal Waste { get; set; }

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

        [JsonProperty("RowVer")]
        public byte[] RowVer { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlanPatil")]
        public ProductionPlanPatilsDTO ProductionPlanPatil { get; set; }

        [JsonProperty("InvProduct")]
        public InvProductsDTO InvProduct { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }

        [JsonProperty("WeightingProductDetailList")]
        public List<WeightingProductDetailDTO> WeightingProductDetailList { get; set; }



    }
}