using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("Label")]
    public class Label : IEntity
    {
        #region Base properties
        [Key]
        [Column("LabelID")]
        [JsonProperty("LabelID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int LabelID { get; set; }

        [Column("LabelName")]
        [JsonProperty("LabelName")]



        public string LabelName { get; set; }

        [Column("ZebraCommand")]
        [JsonProperty("ZebraCommand")]



        public string ZebraCommand { get; set; }
        #endregion Base properties

    }
}