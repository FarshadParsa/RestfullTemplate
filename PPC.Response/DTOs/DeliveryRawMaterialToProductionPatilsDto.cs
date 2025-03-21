using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class DeliveryRawMaterialToProductionPatilsDTO
    {

        #region Base properties
        [JsonProperty("DeliveryRawMaterialToProductionPatilID")]
        public int DeliveryRawMaterialToProductionPatilID { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionID")]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [JsonProperty("ProductionPlanPatilID")]
        public int ProductionPlanPatilID { get; set; }
        #endregion Base properties

        [JsonProperty("DeliveryRawMaterialToProduction")]
        public DeliveryRawMaterialToProductionDTO DeliveryRawMaterialToProduction { get; set; }

        [JsonProperty("ProductionPlanPatil")]
        public ProductionPlanPatilsDTO ProductionPlanPatil { get; set; }

    }
}