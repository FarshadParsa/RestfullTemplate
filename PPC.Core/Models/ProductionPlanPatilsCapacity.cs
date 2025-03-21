using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("ProductionPlanPatilsCapacity")]
    public class ProductionPlanPatilsCapacity : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanPatilCapacityID")]
        [JsonProperty("ProductionPlanPatilCapacityID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanPatilCapacityID { get; set; }

        [Column("ProductionPlanID")]
        [JsonProperty("ProductionPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanID { get; set; }

        [Column("Capacity")]
        [JsonProperty("Capacity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int Capacity { get; set; }

        [Column("QTY")]
        [JsonProperty("QTY")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int QTY { get; set; }
        #endregion Base properties

        [JsonProperty("ProductionPlan")]
        [ForeignKey(nameof(ProductionPlanID))]
        public ProductionPlans ProductionPlan { get; set; }


    }
}