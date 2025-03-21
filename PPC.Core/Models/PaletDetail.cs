using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("PaletDetail")]
    public class PaletDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("PaletDetailID")]
        [JsonProperty("PaletDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PaletDetailID { get; set; }

        [Column("InvProductID")]
        [JsonProperty("InvProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int InvProductID { get; set; }

        [Column("PaletID")]
        [JsonProperty("PaletID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PaletID { get; set; }
        #endregion Base properties

        [JsonProperty("InvProduct")]
        [ForeignKey(nameof(InvProductID))]
        public InvProducts InvProduct  { get; set; }

        [JsonProperty("Palet")]
        [ForeignKey(nameof(PaletID))]
        public Palets Palet { get; set; }

    }
}