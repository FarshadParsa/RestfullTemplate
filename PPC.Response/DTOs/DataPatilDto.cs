using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class DataPatilDTO
    {

        #region Base properties
        [JsonProperty("DataPatilID")]
        public int DataPatilID { get; set; }

        [JsonProperty("DataProductionID")]
        public int DataProductionID { get; set; }

        [JsonProperty("PatilID")]
        public int PatilID { get; set; }

        [JsonProperty("Capacity")]
        public short Capacity { get; set; }

        [JsonProperty("EmptyWeight")]
        public decimal EmptyWeight { get; set; }

        [JsonProperty("AfterChargeWeight")]
        public decimal AfterChargeWeight { get; set; }

        [JsonProperty("AfterFirstMixWeight")]
        public decimal AfterFirstMixWeight { get; set; }

        [JsonProperty("DuringGrindingWeight")]
        public decimal DuringGrindingWeight { get; set; }

        [JsonProperty("FinalWeight")]
        public decimal FinalWeight { get; set; }

        [JsonProperty("NetWeight")]
        public decimal NetWeight { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }
        #endregion Base properties

    }
}