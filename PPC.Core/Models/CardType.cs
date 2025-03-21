using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("CardType")]
    public class CardTypes : IEntity
    {
        #region Base properties
        [Key]
        [Column("CardTypeID")]
        [JsonProperty("CardTypeID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public byte CardTypeID { get; set; }

        [Column("CardTypeName")]
        [JsonProperty("CardTypeName")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(25)]

        public string CardTypeName { get; set; }

        [Column("CardTypeVal")]
        [JsonProperty("CardTypeVal")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]

        public string CardTypeVal { get; set; }

        [Column("OrderBy")]
        [JsonProperty("OrderBy")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte OrderBy { get; set; }

        [Column("IsEntry")]
        [JsonProperty("IsEntry")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsEntry { get; set; }

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsActive { get; set; }
        #endregion Base properties

    }
}