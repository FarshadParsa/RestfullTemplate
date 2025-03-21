using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class DataGrindingDetailDTO
    {

        #region Base properties
        [JsonProperty("DataGrindingDetailID")]
        public int DataGrindingDetailID { get; set; }

        [JsonProperty("DataProductionID")]
        public int DataProductionID { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("DateTimeSaveDistance")]
        public short DateTimeSaveDistance { get; set; }

        [JsonProperty("PressurePump")]
        public decimal PressurePump { get; set; }

        [JsonProperty("MaterialFlowSpeed")]
        public short MaterialFlowSpeed { get; set; }

        [JsonProperty("Duration")]
        public short Duration { get; set; }

        [JsonProperty("GrindingSpeed")]
        public short GrindingSpeed { get; set; }

        [JsonProperty("EnginePower")]
        public decimal EnginePower { get; set; }

        [JsonProperty("MaterialTemp")]
        public byte MaterialTemp { get; set; }

        [JsonProperty("MixerSpeed")]
        public decimal MixerSpeed { get; set; }

        [JsonProperty("Operator")]
        public string Operator { get; set; }

        [JsonProperty("Energy")]
        public decimal Energy { get; set; }

        [JsonProperty("RotorSpeed")]
        public decimal RotorSpeed { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        #endregion Base properties

        [JsonProperty("DataProduction")]
        public DataProductionDTO DataProduction { get; set; }

    }
}