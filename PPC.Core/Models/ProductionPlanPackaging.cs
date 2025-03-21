using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("ProductionPlanPackaging")]
    public class ProductionPlanPackaging : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanPackagingID")]
        [JsonProperty("ProductionPlanPackagingID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanPackagingID { get; set; }

        [Column("ProductionPlanID")]
        [JsonProperty("ProductionPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanID { get; set; }

        [Column("Priority")]
        [JsonProperty("Priority")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte Priority { get; set; }

        [Column("PackagingPlanID")]
        [JsonProperty("PackagingPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PackagingPlanID { get; set; }

        [Column("QTY")]
        [JsonProperty("QTY")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short QTY { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlan")]
        [ForeignKey(nameof(ProductionPlanID))]
        public ProductionPlans ProductionPlan { get; set; }

        [JsonProperty("PackagingPlan")]
        [ForeignKey(nameof(PackagingPlanID))]
        public PackagingPlans PackagingPlan { get; set; }


    }
}