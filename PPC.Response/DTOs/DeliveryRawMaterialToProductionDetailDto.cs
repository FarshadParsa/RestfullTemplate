using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class DeliveryRawMaterialToProductionDetailDTO
    {

        #region Base properties
        [JsonProperty("DeliveryRawMaterialToProductionDetailID")]
        public int DeliveryRawMaterialToProductionDetailID { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionID")]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("Planned")]
        public decimal Planned { get; set; }

        [JsonProperty("InvProduction")]
        public decimal InvProduction { get; set; }

        [JsonProperty("RemainingToProduction")]
        public decimal RemainingToProduction { get; set; }

        [JsonProperty("RequestedAmount")]
        public decimal RequestedAmount { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }
        #endregion Base properties


        [JsonProperty("DeliveryRawMaterialToProduction")]
        public DeliveryRawMaterialToProductionDTO DeliveryRawMaterialToProduction { get; set; }

        [JsonProperty("RawMaterial")]
        public RawMaterialsDTO RawMaterial { get; set; }


    }
}