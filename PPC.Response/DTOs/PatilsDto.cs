using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class PatilsDTO
    {

        #region Base properties
        [JsonProperty("PatilID")]
        public int PatilID { get; set; }

        [JsonProperty("PatilNo")]
        public short PatilNo { get; set; }

        [JsonProperty("Capacity")]
        public short Capacity { get; set; }

        [JsonProperty("MinCapacity")]
        public short MinCapacity { get; set; }

        [JsonProperty("EmptyWeight")]
        public decimal EmptyWeight { get; set; }

        [JsonProperty("InUse")]
        public bool InUse { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        #endregion Base properties

    }
}