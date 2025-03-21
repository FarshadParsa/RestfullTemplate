using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class DeliveryRawMaterialToProductionDTO
    {

        #region Base properties
        [JsonProperty("DeliveryRawMaterialToProductionID")]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [JsonProperty("RequestNo")]
        public int RequestNo { get; set; }

        [JsonProperty("RequestDate")]
        public string RequestDate { get; set; }

        [JsonProperty("RequesterID")]
        public int RequesterID { get; set; }

        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("Status")]
        public byte Status { get; set; }

        [JsonProperty("InsUserID")]
        public int InsUserID { get; set; }

        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [JsonProperty("IsDraft")]
        public bool IsDraft { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        //[JsonProperty("RowVer")]
        //public byte[] RowVer { get; set; }
        #endregion Base properties

        [JsonProperty("ProductionPlan")]
        public ProductionPlansDTO ProductionPlan { get; set; }

        [JsonProperty("Requester")]
        public UsersDTO Requester { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionDetailList")]
        public List<DeliveryRawMaterialToProductionDetailDTO> DeliveryRawMaterialToProductionDetailList { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionPatilList")]
        public List<DeliveryRawMaterialToProductionPatilsDTO> DeliveryRawMaterialToProductionPatilList { get; set; }


    }
}