using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("Patils")]
    public class Patils : IEntity
    {
        #region Base properties
        [Key]
        [Column("PatilID")]
        [JsonProperty("PatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int PatilID { get; set; }

        [Column("PatilNo")]
        [JsonProperty("PatilNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short PatilNo { get; set; }

        [Column("Capacity")]
        [JsonProperty("Capacity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short Capacity { get; set; }

        [Column("MinCapacity")]
        [JsonProperty("MinCapacity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short MinCapacity { get; set; }

        [Column("EmptyWeight")]
        [JsonProperty("EmptyWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal EmptyWeight { get; set; }

        [Column("InUse")]
        [JsonProperty("InUse")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool InUse { get; set; }

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsActive { get; set; }
        #endregion Base properties

    }
}