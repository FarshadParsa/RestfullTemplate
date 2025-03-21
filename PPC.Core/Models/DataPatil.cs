using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("DataPatil")]
    public class DataPatil : IEntity
    {
        #region Base properties
        [Key]
        [Column("DataPatilID")]
        [JsonProperty("DataPatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DataPatilID { get; set; }

        [Column("DataProductionID")]
        [JsonProperty("DataProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int DataProductionID { get; set; }

        [Column("PatilID")]
        [JsonProperty("PatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int PatilID { get; set; }

        [Column("Capacity")]
        [JsonProperty("Capacity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short Capacity { get; set; }

        [Column("EmptyWeight")]
        [JsonProperty("EmptyWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal EmptyWeight { get; set; }

        [Column("AfterChargeWeight")]
        [JsonProperty("AfterChargeWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal AfterChargeWeight { get; set; }

        [Column("AfterFirstMixWeight")]
        [JsonProperty("AfterFirstMixWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal AfterFirstMixWeight { get; set; }

        [Column("DuringGrindingWeight")]
        [JsonProperty("DuringGrindingWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal DuringGrindingWeight { get; set; }

        [Column("FinalWeight")]
        [JsonProperty("FinalWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal FinalWeight { get; set; }

        [Column("NetWeight")]
        [JsonProperty("NetWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal NetWeight { get; set; }

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