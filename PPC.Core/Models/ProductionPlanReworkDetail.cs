using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("ProductionPlanReworkDetail")]
    public class ProductionPlanReworkDetails : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanReworkDetailID")]
        [JsonProperty("ProductionPlanReworkDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanReworkDetailID { get; set; }

        [Column("ProductionPlanReworkID")]
        [JsonProperty("ProductionPlanReworkID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanReworkID { get; set; }

        [Column("ProductionPlanBOMDetailID")]
        [JsonProperty("ProductionPlanBOMDetailID")]
        public int? ProductionPlanBOMDetailID { get; set; }

        [Column("ProductionPlanBOMDetailRevisedID")]
        [JsonProperty("ProductionPlanBOMDetailRevisedID")]
        public int? ProductionPlanBOMDetailRevisedID { get; set; }

        [Column("ParentID")]
        [JsonProperty("ParentID")]
        public int? ParentID { get; set; }

        [Column("BOMDetailID")]
        [JsonProperty("BOMDetailID")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int? BOMDetailID { get; set; }

        [Column("RMWhiteListID")]
        [JsonProperty("RMWhiteListID")]
        public int? RMWhiteListID { get; set; }

        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialID { get; set; }

        [Column("Priority")]
        [JsonProperty("Priority")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]
        public string Priority { get; set; }

        [Column("Percentage")]
        [JsonProperty("Percentage")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Percentage { get; set; }

        [Column("PlannedWeight")]
        [JsonProperty("PlannedWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal PlannedWeight { get; set; }

        [Column("PlanningDescribe")]
        [JsonProperty("PlanningDescribe")]
        [MaxLength(250)]
        public string PlanningDescribe { get; set; }

        [Column("WronglyMixed")]
        [JsonProperty("WronglyMixed")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public bool WronglyMixed { get; set; }

        [Column("ActualWeight")]
        [JsonProperty("ActualWeight")]
        public decimal? ActualWeight { get; set; }

        [Column("ActualPercentage")]
        [JsonProperty("ActualPercentage")]
        public decimal? ActualPercentage { get; set; }

        [Column("NewChargeWeight")]
        [JsonProperty("NewChargeWeight")]
        public decimal? NewChargeWeight { get; set; }

        [Column("NewChargePercent")]
        [JsonProperty("NewChargePercent")]
        public decimal? NewChargePercent { get; set; }

        [Column("NewWeight")]
        [JsonProperty("NewWeight")]
        public decimal? NewWeight { get; set; }

        [Column("ManualAdded")]
        [JsonProperty("ManualAdded")]
        public bool? ManualAdded { get; set; }

        [Column("LotNo")]
        [JsonProperty("LotNo")]
        [MaxLength(50)]
        public string LotNo { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(200)]
        public string Describe { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlanRework")]
        public ProductionPlanReworks ProductionPlanRework { get; set; }

        [JsonProperty("ProductionPlanBOMDetail")]
        public ProductionPlanBOMDetail ProductionPlanBOMDetail{ get; set; }

        [JsonProperty("ProductionPlanBOMDetailRevised")]
        public ProductionPlanBOMDetailRevised ProductionPlanBOMDetailRevisedI{ get; set; }

        [JsonProperty("Parent")]
        public ProductionPlanReworkDetails Parent{ get; set; }

        [JsonProperty("BOMDetail")]
        public BOMDetail BOMDetail{ get; set; }

        [JsonProperty("RMWhiteList")]
        public RMWhiteLists RMWhiteList { get; set; }

        [JsonProperty("RawMaterial")]
        public RawMaterials RawMaterial { get; set; }


    }
}