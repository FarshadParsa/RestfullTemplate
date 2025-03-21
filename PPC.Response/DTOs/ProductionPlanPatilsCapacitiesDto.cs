using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class ProductionPlanPatilsCapacityDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanPatilCapacityID")]
        public int ProductionPlanPatilCapacityID { get; set; }

        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("Capacity")]
        public int Capacity { get; set; }

        [JsonProperty("QTY")]
        public int QTY { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlan")]
        public ProductionPlansDTO ProductionPlan { get; set; }


    }
}