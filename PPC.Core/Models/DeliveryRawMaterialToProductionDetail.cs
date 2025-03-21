using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("DeliveryRawMaterialToProductionDetail")]
    public class DeliveryRawMaterialToProductionDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("DeliveryRawMaterialToProductionDetailID")]
        [JsonProperty("DeliveryRawMaterialToProductionDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DeliveryRawMaterialToProductionDetailID { get; set; }

        [Column("DeliveryRawMaterialToProductionID")]
        [JsonProperty("DeliveryRawMaterialToProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialID { get; set; }

        [Column("Planned")]
        [JsonProperty("Planned")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Planned { get; set; }

        [Column("InvProduction")]
        [JsonProperty("InvProduction")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal InvProduction { get; set; }

        [Column("RemainingToProduction")]
        [JsonProperty("RemainingToProduction")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal RemainingToProduction { get; set; }

        [Column("RequestedAmount")]
        [JsonProperty("RequestedAmount")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal RequestedAmount { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(250)]
        public string Describe { get; set; }
        #endregion Base properties

        [JsonProperty("DeliveryRawMaterialToProduction")]
        [ForeignKey(nameof(DeliveryRawMaterialToProductionID))]
        public DeliveryRawMaterialToProduction DeliveryRawMaterialToProduction { get; set; }

        [JsonProperty("RawMaterial")]
        [ForeignKey(nameof(RawMaterialID))]
        public RawMaterials RawMaterial { get; set; }


    }
}