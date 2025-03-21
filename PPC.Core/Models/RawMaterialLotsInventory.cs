using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("RawMaterialLotsInventory")]
    public class RawMaterialLotsInventory : IEntity
    {
        #region Base properties
        [Key]
        [Column("LotNo")]
        [JsonProperty("LotNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(20)]
        public string LotNo { get; set; }

        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int RawMaterialID { get; set; }

        [Column("ExpireDate")]
        [JsonProperty("ExpireDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string ExpireDate { get; set; }

        [Column("NetWeight")]
        [JsonProperty("NetWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal NetWeight { get; set; }

        [Column("DeliveredAmount")]
        [JsonProperty("DeliveredAmount")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal DeliveredAmount { get; set; }

        [Column("RemainingWeight")]
        [JsonProperty("RemainingWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal RemainingWeight { get; set; }
        #endregion Base properties

        [JsonProperty("RawMaterial")]
        [ForeignKey(nameof(RawMaterialID))]
        public RawMaterials RawMaterial { get; set; }


    }
}