using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("CustomerDossierBOMs")]
    public class CustomerDossierBOMs : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("CustomerDossierBOMID")]
        [JsonProperty("CustomerDossierBOMID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int CustomerDossierBOMID { get; set; }

        [Column("CustomerDossierID")]
        [JsonProperty("CustomerDossierID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int CustomerDossierID { get; set; }

        [Column("BOMID")]
        [JsonProperty("BOMID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int BOMID { get; set; }

        [Column("StartDate")]
        [JsonProperty("StartDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string StartDate { get; set; }

        [Column("StartTime")]
        [JsonProperty("StartTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string StartTime { get; set; }

        [Column("EndDate")]
        [JsonProperty("EndDate")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string EndDate { get; set; }

        [Column("EndTime")]
        [JsonProperty("EndTime")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string EndTime { get; set; }

        [Column("Ver")]
        [JsonProperty("Ver")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short Ver { get; set; }

        [Column("SerialNumber")]
        [JsonProperty("SerialNumber")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int SerialNumber { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(250)]
        public string Describe { get; set; }

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public bool IsActive { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)


        [JsonProperty("CustomerDossier")]
        [ForeignKey(nameof(CustomerDossierID))]
        public CustomerDossier CustomerDossier { get; set; }

        [JsonProperty("BOM")]
        [ForeignKey(nameof(BOMID))]
        public BOM BOM { get; set; }


    }
}