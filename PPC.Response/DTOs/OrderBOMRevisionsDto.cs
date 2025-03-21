using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class OrderBOMRevisionsDTO
    {

        #region Base properties
        [JsonProperty("OrderBOMReviseID")]
        public int OrderBOMReviseID { get; set; }

        [JsonProperty("OrderDetailID")]
        public int OrderDetailID { get; set; }

        [JsonProperty("OldBOMID")]
        public int? OldBOMID { get; set; }

        [JsonProperty("NewBOMID")]
        public int NewBOMID { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

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


        [JsonProperty("OrderDetail")]
        public OrderDetailsDTO OrderDetail { get; set; }

        [JsonProperty("BOM_OldBOM")]
        public BOMDTO BOM_OldBOM { get; set; }

        [JsonProperty("BOM_NewBOM")]
        public BOMDTO BOM_NewBOM { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }

    }
}