using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class RawMaterialsDeliveredToProductionDetailDTO
    {

        #region Base properties
        [JsonProperty("RawMaterialsDeliveredToProductionDetailID")]
        public int RawMaterialsDeliveredToProductionDetailID { get; set; }

        [JsonProperty("RawMaterialsDeliveredToProductionID")]
        public int RawMaterialsDeliveredToProductionID { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("RequestedAmount")]
        public decimal RequestedAmount { get; set; }

        [JsonProperty("DeliveredAmount")]
        public decimal DeliveredAmount { get; set; }

        [JsonProperty("GeneralLotNumber")]
        public string GeneralLotNumber { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }
        #endregion Base properties


        [JsonProperty("RawMaterialsDeliveredToProduction")]
        public RawMaterialsDeliveredToProductionDTO RawMaterialsDeliveredToProduction { get; set; }

        [JsonProperty("RawMaterial")]
        public RawMaterialsDTO RawMaterial { get; set; }


    }
}