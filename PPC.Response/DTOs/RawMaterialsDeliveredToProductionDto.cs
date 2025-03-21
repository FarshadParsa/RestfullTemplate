using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Response.DTOs
{
    public class RawMaterialsDeliveredToProductionDTO
    {

        #region Base properties
        [JsonProperty("RawMaterialsDeliveredToProductionID")]
        public int RawMaterialsDeliveredToProductionID { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionID")]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [JsonProperty("DeliverDate")]
        public string DeliverDate { get; set; }

        [JsonProperty("DeliverTime")]
        public string DeliverTime { get; set; }

        [JsonProperty("DeliveryUserID")]
        public int DeliveryUserID { get; set; }

        [JsonProperty("ReceivingUserID")]
        public int ReceivingUserID { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

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

        [JsonProperty("RowVer")]
        public byte[]? RowVer { get; set; }
        #endregion Base properties

        [JsonProperty("DeliveryRawMaterialToProduction")]
        public DeliveryRawMaterialToProductionDTO DeliveryRawMaterialToProduction { get; set; }

        [JsonProperty("DeliveryUser")]
        public UsersDTO DeliveryUser { get; set; }

        [JsonProperty("ReceivingUser")]
        public UsersDTO ReceivingUser { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }

        [JsonProperty("RawMaterialsDeliveredToProductionDetailList")]
        public List<RawMaterialsDeliveredToProductionDetailDTO> RawMaterialsDeliveredToProductionDetailList { get; set; }


    }
}