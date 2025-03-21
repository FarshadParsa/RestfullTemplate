using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class DataGrindingDTO
    {

        #region Base properties
        [JsonProperty("DataGrindingID")]
        public int DataGrindingID { get; set; }

        [JsonProperty("DataProductionID")]
        public int DataProductionID { get; set; }

        [JsonProperty("StationID")]
        public int StationID { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("Duration")]
        public short Duration { get; set; }

        [JsonProperty("ShiftNo")]
        public string ShiftNo { get; set; }

        [JsonProperty("Operators")]
        public string Operators { get; set; }

        [JsonProperty("Stopes")]
        public short Stopes { get; set; }

        [JsonProperty("StopesDesc")]
        public string StopesDesc { get; set; }

        [JsonProperty("StationSpeed")]
        public short StationSpeed { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }
        #endregion Base properties


    }
}