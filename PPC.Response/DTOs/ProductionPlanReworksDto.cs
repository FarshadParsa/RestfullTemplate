using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class ProductionPlanReworksDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanReworkID")]
        public int ProductionPlanReworkID { get; set; }

        [JsonProperty("ProductionPlanPatilID")]
        public int ProductionPlanPatilID { get; set; }

        [JsonProperty("LevelNo")]
        public byte LevelNo { get; set; }

        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        [JsonProperty("CorrectiveActionType")]
        public byte CorrectiveActionType { get; set; }

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

        [JsonProperty("DelUserID")]
        public int? DelUserID { get; set; }

        [JsonProperty("DelDate")]
        public string DelDate { get; set; }

        [JsonProperty("DelTime")]
        public string DelTime { get; set; }


        [JsonProperty("ProductionPlanLastStatus")]
        public byte ProductionPlanLastStatus { get; set; }

        #endregion Base properties


        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }

        [JsonProperty("User_DelUser")]
        public UsersDTO User_DelUser { get; set; }

        [JsonProperty("Product")]
        public ProductsDTO Product { get; set; }


        [JsonProperty("ProductionPlanPatil")]
        public ProductionPlanPatilsDTO ProductionPlanPatil { get; set; }

        [JsonProperty("ProductionPlanReworkDetailList")]
        public virtual System.Collections.Generic.List<ProductionPlanReworkDetailsDTO> ProductionPlanReworkDetailList { get; set; }

    }
}