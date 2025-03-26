using Newtonsoft.Json;

namespace WebApi.Response.DTOs
{
    public class DomainDTO
    {

        [JsonProperty("DomainID")]
        public int DomainID { get; set; }

        [JsonProperty("DomainName")]
        public string DomainName { get; set; }

        [JsonProperty("DomainAddress")]
        public string DomainAddress { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }
        
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }



    }
}
