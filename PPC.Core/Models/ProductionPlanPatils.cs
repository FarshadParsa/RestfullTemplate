using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("ProductionPlanPatils")]
    public class ProductionPlanPatils : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanPatilID")]
        [JsonProperty("ProductionPlanPatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanPatilID { get; set; }

        [Column("ProductionPlanID")]
        [JsonProperty("ProductionPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanID { get; set; }

        [Column("LotNoNum")]
        [JsonProperty("LotNoNum")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte LotNoNum { get; set; }

        [Column("LotNo")]
        [JsonProperty("LotNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string LotNo { get; set; }

        [Column("PlannedCapacity")]
        [JsonProperty("PlannedCapacity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short PlannedCapacity { get; set; }
        #endregion Base properties

        [JsonProperty("ProductionPlan")]
        [ForeignKey(nameof(ProductionPlanID))]
        public ProductionPlans ProductionPlan { get; set; }


        [JsonProperty("DataProductionLis")]
        public List<DataProduction> DataProductionLis { get; set; }


        [JsonProperty("ProductionPlanReworksList")]
        [ForeignKey(nameof(ProductionPlanPatilID))]
        public List<ProductionPlanReworks> ProductionPlanReworksList { get; set; }


    }
}