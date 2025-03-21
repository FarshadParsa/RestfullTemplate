using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class DataDosingDetailDTO
    {

        #region Base properties
        [JsonProperty("DataDosingDetailID")]
        public int DataDosingDetailID { get; set; }

        [JsonProperty("DataProductionID")]
        public int DataProductionID { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("RawMaterialType")]
        public string RawMaterialType { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("PlannedWeight")]
        public int PlannedWeight { get; set; }

        [JsonProperty("ChargedWeight")]
        public decimal? ChargedWeight { get; set; }

        [JsonProperty("LotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("Wastes")]
        public decimal Wastes { get; set; }

        [JsonProperty("Operator")]
        public string Operator { get; set; }

        [JsonProperty("IsFinalRM")]
        public bool IsFinalRM { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }
        #endregion Base properties


        [JsonProperty("DataProduction")]
        public DataProductionDTO DataProduction { get; set; }

        [JsonProperty("RawMaterial")]
        public RawMaterialsDTO RawMaterial { get; set; }

    }
}