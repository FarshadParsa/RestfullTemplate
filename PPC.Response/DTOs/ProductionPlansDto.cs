using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Response.DTOs
{
    public class ProductionPlansDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("OrderDetailID")]
        public int OrderDetailID { get; set; }

        [JsonProperty("ProducibleQuantity")]
        public int ProducibleQuantity { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("BatchNo")]
        public string BatchNo { get; set; }

        [JsonProperty("ProductionProcessCirculation")]
        public byte ProductionProcessCirculation { get; set; }

        [JsonProperty("ProductionProcessType")]
        public byte? ProductionProcessType { get; set; }

        [JsonProperty("TransferToInvRM")]
        public bool TransferToInvRM { get; set; }

        [JsonProperty("TransferToWarehouse")]
        public bool TransferToWarehouse { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        [JsonProperty("Status")]
        public byte Status { get; set; }

        [JsonProperty("IsDraft")]
        public bool IsDraft { get; set; }

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

        #endregion Base properties


        [JsonProperty("OrderDetail")]
        public OrderDetailsDTO OrderDetail { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }


        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }


        [JsonProperty("ProductionPlanPackagingList")]
        public List<ProductionPlanPackagingDTO> ProductionPlanPackagingList { get; set; }


        [JsonProperty("ProductionPlanPatilsCapacityList")]
        public List<ProductionPlanPatilsCapacityDTO> ProductionPlanPatilsCapacityList { get; set; }

        [JsonProperty("ProductionPlanBOMDetailList")]
        public List<ProductionPlanBOMDetailDTO> ProductionPlanBOMDetailList { get; set; }

        [JsonProperty("ProductionPlanPatilList")]
        public List<ProductionPlanPatilsDTO> ProductionPlanPatilList { get; set; }


    }
}