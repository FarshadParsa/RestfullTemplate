using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using PPC.Response.DTOs;

namespace PPC.Core.Models
{
    [Table("DeliveryRawMaterialToProductionPatils")]
    public class DeliveryRawMaterialToProductionPatils : IEntity
    {
        #region Base properties
        [Key]
        [Column("DeliveryRawMaterialToProductionPatilID")]
        [JsonProperty("DeliveryRawMaterialToProductionPatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DeliveryRawMaterialToProductionPatilID { get; set; }

        [Column("DeliveryRawMaterialToProductionID")]
        [JsonProperty("DeliveryRawMaterialToProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int DeliveryRawMaterialToProductionID { get; set; }

        [Column("ProductionPlanPatilID")]
        [JsonProperty("ProductionPlanPatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanPatilID { get; set; }
        #endregion Base properties

        [JsonProperty("DeliveryRawMaterialToProduction")]
        [ForeignKey(nameof(DeliveryRawMaterialToProductionID))]
        public DeliveryRawMaterialToProduction DeliveryRawMaterialToProduction { get; set; }

        [JsonProperty("ProductionPlanPatil")]
        [ForeignKey(nameof(ProductionPlanPatilID))]
        public ProductionPlanPatils ProductionPlanPatil { get; set; }

    }
}