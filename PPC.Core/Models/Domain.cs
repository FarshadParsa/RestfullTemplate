using Newtonsoft.Json;
using WebApi.Core.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Core.Models
{

    [Table("Domain")]
    public class Domain: IEntity
    {
        [Key]
        [Column("DomainID")]
        [JsonProperty("DomainID")]
        public byte DomainID { get; set; }

        [Column("DomainName")]
        [JsonProperty("DomainName")]
        public string DomainName { get; set; } = string.Empty;

        [Column("DomainAddress")]
        [JsonProperty("DomainAddress")]
        public string DomainAddress { get; set; } = string.Empty;

        [Column("Describe")]
        [JsonProperty("Describe")]
        public string Describe { get; set; } = string.Empty;

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; } = true;

        public Domain()
        {

        }


    }
}
