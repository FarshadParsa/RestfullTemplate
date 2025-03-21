using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class ProductionPlanReworkDetailsDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanReworkDetailID")]
        public int ProductionPlanReworkDetailID { get; set; }

        [JsonProperty("ProductionPlanReworkID")]
        public int ProductionPlanReworkID { get; set; }

        [JsonProperty("ProductionPlanBOMDetailID")]
        public int? ProductionPlanBOMDetailID { get; set; }

        [JsonProperty("ProductionPlanBOMDetailRevisedID")]
        public int? ProductionPlanBOMDetailRevisedID { get; set; }

        [JsonProperty("ParentID")]
        public int? ParentID { get; set; }

        [JsonProperty("BOMDetailID")]
        public int? BOMDetailID { get; set; }

        [JsonProperty("RMWhiteListID")]
        public int? RMWhiteListID { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Percentage")]
        public decimal Percentage { get; set; }

        [JsonProperty("PlannedWeight")]
        public decimal PlannedWeight { get; set; }

        [JsonProperty("PlanningDescribe")]
        public string PlanningDescribe { get; set; }

        [JsonProperty("WronglyMixed")]
        public bool WronglyMixed { get; set; }

        [JsonProperty("ActualWeight")]
        public decimal? ActualWeight { get; set; }

        [JsonProperty("ActualPercentage")]
        public decimal? ActualPercentage { get; set; }

        [JsonProperty("NewChargeWeight")]
        public decimal? NewChargeWeight { get; set; }

        [JsonProperty("NewChargePercent")]
        public decimal? NewChargePercent { get; set; }

        [JsonProperty("NewWeight")]
        public decimal? NewWeight { get; set; }

        [JsonProperty("ManualAdded")]
        public bool? ManualAdded { get; set; }

        [JsonProperty("LotNo")]
        public string LotNo { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlanRework")]
        public ProductionPlanReworksDTO ProductionPlanRework { get; set; }

        [JsonProperty("ProductionPlanBOMDetail")]
        public ProductionPlanBOMDetailDTO ProductionPlanBOMDetail { get; set; }

        [JsonProperty("ProductionPlanBOMDetailRevised")]
        public ProductionPlanBOMDetailRevisedDTO ProductionPlanBOMDetailRevisedI { get; set; }

        [JsonProperty("Parent")]
        public ProductionPlanReworkDetailsDTO Parent { get; set; }

        [JsonProperty("BOMDetail")]
        public BOMDetailDTO BOMDetail { get; set; }

        [JsonProperty("RMWhiteList")]
        public RMWhiteListsDTO RMWhiteList { get; set; }

        [JsonProperty("RawMaterial")]
        public RawMaterialsDTO RawMaterial { get; set; }

    }
}