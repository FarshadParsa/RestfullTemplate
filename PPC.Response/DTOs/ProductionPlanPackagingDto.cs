using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class ProductionPlanPackagingDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanPackagingID")]
        public int ProductionPlanPackagingID { get; set; }

        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("Priority")]
        public byte Priority { get; set; }

        [JsonProperty("PackagingPlanID")]
        public int PackagingPlanID { get; set; }

        [JsonProperty("QTY")]
        public short QTY { get; set; }
        #endregion Base properties



        [JsonProperty("ProductionPlan")]
        public ProductionPlansDTO ProductionPlan { get; set; }

        [JsonProperty("PackagingPlan")]
        public PackagingPlansDTO PackagingPlan { get; set; }


    }
}