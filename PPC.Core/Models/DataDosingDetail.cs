using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("DataDosingDetail")]
    public class DataDosingDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("DataDosingDetailID")]
        [JsonProperty("DataDosingDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DataDosingDetailID { get; set; }

        [Column("DataProductionID")]
        [JsonProperty("DataProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int DataProductionID { get; set; }

        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int RawMaterialID { get; set; }

        [Column("RawMaterialType")]
        [JsonProperty("RawMaterialType")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]

        public string RawMaterialType { get; set; }

        [Column("Priority")]
        [JsonProperty("Priority")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]

        public string Priority { get; set; }

        [Column("PlannedWeight")]
        [JsonProperty("PlannedWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int PlannedWeight { get; set; }

        [Column("ChargedWeight")]
        [JsonProperty("ChargedWeight")]



        public decimal? ChargedWeight { get; set; }

        [Column("LotNumber")]
        [JsonProperty("LotNumber")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(15)]

        public string LotNumber { get; set; }

        [Column("Wastes")]
        [JsonProperty("Wastes")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Wastes { get; set; }

        [Column("Operator")]
        [JsonProperty("Operator")]

        [MaxLength(15)]
        public string Operator { get; set; }


        [Column("IsFinalRM")]
        [JsonProperty("IsFinalRM")]
        public bool IsFinalRM { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(150)]
        public string Describe { get; set; }
        #endregion Base properties

        [JsonProperty("DataProduction")]
        [ForeignKey(nameof(DataProductionID))]
        public DataProduction DataProduction { get; set; }

        [JsonProperty("RawMaterial")]
        [ForeignKey(nameof(RawMaterialID))]
        public RawMaterials RawMaterial { get; set; }



    }
}