using Newtonsoft.Json;
using System;
namespace PPC.Response.DTOs
{
    public class ProductionPlanBOMDetailRevisedDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanBOMDetailRevisedID")]
        public int ProductionPlanBOMDetailRevisedID { get; set; }

        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("BOMDetailID")]
        public int? BOMDetailID { get; set; }

        [JsonProperty("RawMaterialType")]
        public string RawMaterialType { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Planned")]
        public decimal Planned { get; set; }

        [JsonProperty("Stock")]
        public decimal Stock { get; set; }

        [JsonProperty("PlanningReserved")]
        public decimal PlanningReserved { get; set; }

        [JsonProperty("Expiration")]
        public string Expiration { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        [JsonProperty("PlaningDescribe")]
        public string PlaningDescribe { get; set; }

        [JsonProperty("Percentage")]
        public decimal Percentage { get; set; }

        [JsonProperty("RequiredWeight")]
        public decimal RequiredWeight { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        [JsonProperty("InsDate")]
        public DateTime InsDate { get; set; }

        #endregion Base properties


        [JsonProperty("ProductionPlan")]
        public ProductionPlansDTO ProductionPlan { get; set; }

        [JsonProperty("BOMDetail")]
        public BOMDetailDTO BOMDetail { get; set; }

    }
}