using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("RawMaterialsDeliveredToProductionDetail")]
    public class RawMaterialsDeliveredToProductionDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("RawMaterialsDeliveredToProductionDetailID")]
        [JsonProperty("RawMaterialsDeliveredToProductionDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialsDeliveredToProductionDetailID { get; set; }


        [Column("RawMaterialsDeliveredToProductionID")]
        [JsonProperty("RawMaterialsDeliveredToProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialsDeliveredToProductionID { get; set; }

        
        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialID { get; set; }


        [Column("RequestedAmount")]
        [JsonProperty("RequestedAmount")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal RequestedAmount { get; set; }

        
        [Column("DeliveredAmount")]
        [JsonProperty("DeliveredAmount")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal DeliveredAmount { get; set; }

        
        [Column("GeneralLotNumber")]
        [JsonProperty("GeneralLotNumber")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(15)]
        public string GeneralLotNumber { get; set; }

        
        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(100)]
        public string Describe { get; set; }
        #endregion Base properties

        [JsonProperty("RawMaterialsDeliveredToProduction")]
        [ForeignKey(nameof(RawMaterialsDeliveredToProductionID))]
        public RawMaterialsDeliveredToProduction RawMaterialsDeliveredToProduction { get; set; }

        [JsonProperty("RawMaterial")]
        [ForeignKey(nameof(RawMaterialID))]
        public RawMaterials RawMaterial { get; set; }


    }
}