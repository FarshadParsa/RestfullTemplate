using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using PPC.Response.DTOs;

namespace PPC.Core.Models
{
    [Table("CustomerDraftPalets")]
    public class CustomerDraftPalets : IEntity
    {
        #region Base properties
        [Key]
        [Column("CustomerDraftPaletID")]
        [JsonProperty("CustomerDraftPaletID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int CustomerDraftPaletID { get; set; }

        [Column("CustomerDraftID")]
        [JsonProperty("CustomerDraftID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int CustomerDraftID { get; set; }

        [Column("PaletID")]
        [JsonProperty("PaletID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int PaletID { get; set; }
        #endregion Base properties


        [JsonProperty("CustomerDraft")]
        [ForeignKey(nameof(CustomerDraftID))]
        public CustomerDrafts CustomerDraft { get; set; }

        [JsonProperty("Palet")]
        [ForeignKey(nameof(PaletID))]
        public Palets Palet { get; set; }


    }
}