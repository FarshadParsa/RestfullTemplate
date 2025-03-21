using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("DataDosing")]
    public class DataDosing : IEntity
    {
        #region Base properties
        [Key]
        [Column("DataDosingID")]
        [JsonProperty("DataDosingID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DataDosingID { get; set; }

        [Column("DataProductionID")]
        [JsonProperty("DataProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int DataProductionID { get; set; }

        [Column("StartDate")]
        [JsonProperty("StartDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public string StartDate { get; set; }

        [Column("StartTime")]
        [JsonProperty("StartTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string StartTime { get; set; }

        [Column("EndDate")]
        [JsonProperty("EndDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EndDate { get; set; }

        [Column("EndTime")]
        [JsonProperty("EndTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string EndTime { get; set; }

        [Column("Duration")]
        [JsonProperty("Duration")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short Duration { get; set; }

        [Column("WeighbridgeNo")]
        [JsonProperty("WeighbridgeNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte WeighbridgeNo { get; set; }

        [Column("ShiftNo")]
        [JsonProperty("ShiftNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]

        public string ShiftNo { get; set; }

        [Column("Operators")]
        [JsonProperty("Operators")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]

        public string Operators { get; set; }

        [Column("Wastes")]
        [JsonProperty("Wastes")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Wastes { get; set; }

        [Column("Stopes")]
        [JsonProperty("Stopes")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short Stopes { get; set; }

        [Column("StopesDesc")]
        [JsonProperty("StopesDesc")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]

        public string StopesDesc { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]

        [MaxLength(150)]

        public string Describe { get; set; }

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
        #endregion Base properties


    }
}