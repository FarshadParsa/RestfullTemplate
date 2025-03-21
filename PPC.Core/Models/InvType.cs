using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("InvType")]
    public class InvTypes : IEntity
    {
        #region Base properties
        [Key]
        [Column("InvTypeID")]
        [JsonProperty("InvTypeID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public char InvTypeID { get; set; }

        [Column("InvTypeName")]
        [JsonProperty("InvTypeName")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(25)]

        public string InvTypeName { get; set; }

        [Column("OrderBy")]
        [JsonProperty("OrderBy")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte OrderBy { get; set; }

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsActive { get; set; }
        #endregion Base properties

    }
}