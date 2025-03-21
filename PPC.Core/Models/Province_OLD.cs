using Newtonsoft.Json;
using PPC.Core.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPC.Core.Models
{
    [Table("Province")]
    public class Province : IEntity
    {
        [Key]
        [Column("ProvinceID")]
        [JsonProperty("ProvinceID")]
        public System.Int16 ProvinceID { get; set; }

        [Column("ProvinceCode")]
        [JsonProperty("ProvinceCode")]
        public System.String ProvinceCode { get; set; } = string.Empty;

        [Column("ProvinceName")]
        [JsonProperty("ProvinceName")]
        public System.String ProvinceName { get; set; } = string.Empty;

        [Column("ProvinceLatinName")]
        [JsonProperty("ProvinceLatinName")]
        public System.String ProvinceLatinName { get; set; } = string.Empty;

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        public System.Boolean IsActive { get; set; }

        public Province()
        {

        }
    }
}
