using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("DataGrindingDetail")]
    public class DataGrindingDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("DataGrindingDetailID")]
        [JsonProperty("DataGrindingDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DataGrindingDetailID { get; set; }

        [Column("DataProductionID")]
        [JsonProperty("DataProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DataProductionID { get; set; }

        [Column("Date")]
        [JsonProperty("Date")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string Date { get; set; }

        [Column("Time")]
        [JsonProperty("Time")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string Time { get; set; }

        [Column("DateTimeSaveDistance")]
        [JsonProperty("DateTimeSaveDistance")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short DateTimeSaveDistance { get; set; }

        [Column("PressurePump")]
        [JsonProperty("PressurePump")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal PressurePump { get; set; }

        [Column("MaterialFlowSpeed")]
        [JsonProperty("MaterialFlowSpeed")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short MaterialFlowSpeed { get; set; }

        [Column("Duration")]
        [JsonProperty("Duration")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short Duration { get; set; }

        [Column("GrindingSpeed")]
        [JsonProperty("GrindingSpeed")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short GrindingSpeed { get; set; }

        [Column("EnginePower")]
        [JsonProperty("EnginePower")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal EnginePower { get; set; }

        [Column("MaterialTemp")]
        [JsonProperty("MaterialTemp")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte MaterialTemp { get; set; }

        [Column("MixerSpeed")]
        [JsonProperty("MixerSpeed")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal MixerSpeed { get; set; }

        [Column("Operator")]
        [JsonProperty("Operator")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(20)]
        public string Operator { get; set; }

        [Column("Energy")]
        [JsonProperty("Energy")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Energy { get; set; }

        [Column("RotorSpeed")]
        [JsonProperty("RotorSpeed")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal RotorSpeed { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]

        [MaxLength(150)]

        public string Describe { get; set; }

        #endregion Base properties

        [JsonProperty("DataProduction")]
        [ForeignKey(nameof(DataProductionID))]
        public DataProduction DataProduction { get; set; }


    }
}