using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PPC.Core.Models
{
    [Table("ProductionPlanBOMDetail")]
    public class ProductionPlanBOMDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanBOMDetailID")]
        [JsonProperty("ProductionPlanBOMDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanBOMDetailID { get; set; }

        [Column("ProductionPlanID")]
        [JsonProperty("ProductionPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanID { get; set; }

        [Column("BomDetailID")]
        [JsonProperty("BomDetailID")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int? BOMDetailID { get; set; }

        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialID { get; set; }

        [Column("RawMaterialType")]
        [JsonProperty("RawMaterialType")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]
        public string RawMaterialType { get; set; }

        [Column("ComplementaryCount")]
        [JsonProperty("ComplementaryCount")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short ComplementaryCount { get; set; }

        [Column("Priority")]
        [JsonProperty("Priority")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]
        public string Priority { get; set; }

        [Column("BOMComplementaryDesc")]
        [JsonProperty("BOMComplementaryDesc")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public string BOMComplementaryDesc { get; set; }

        [Column("Planned")]
        [JsonProperty("Planned")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Planned { get; set; }

        [Column("Stock")]
        [JsonProperty("Stock")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Stock { get; set; }

        [Column("PlanningReserved")]
        [JsonProperty("PlanningReserved")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal PlanningReserved { get; set; }

        [Column("Expiration")]
        [JsonProperty("Expiration")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string Expiration { get; set; }

        [Column("IsFinalRM")]
        [JsonProperty("IsFinalRM")]
        public bool IsFinalRM { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(250)]
        public string Describe { get; set; }

        [Column("Percentage")]
        [JsonProperty("Percentage")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Percentage { get; set; }

        [Column("RequiredWeight")]
        [JsonProperty("RequiredWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal RequiredWeight { get; set; }

        [Column("EditUserID")]
        [JsonProperty("EditUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int EditUserID { get; set; }

        [Column("EditDate")]
        [JsonProperty("EditDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string EditDate { get; set; }

        [Column("EditTime")]
        [JsonProperty("EditTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string EditTime { get; set; }

        [Column("RowVer")]
        [JsonProperty("RowVer")]
        [Timestamp]
        public byte[] RowVer { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlan")]
        //[ForeignKey(nameof(ProductionPlanID))]
        public ProductionPlans ProductionPlan { get; set; }

        [JsonProperty("BOMDetail")]
        [ForeignKey(nameof(BOMDetailID))]
        public BOMDetail BOMDetail { get; set; }


        [JsonProperty("RawMaterial")]
        [ForeignKey(nameof(RawMaterialID))]
        public RawMaterials RawMaterial { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }



    }
}