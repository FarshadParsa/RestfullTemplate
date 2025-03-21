using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Response.DTOs
{
    public class ProductionPlanPatilsDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanPatilID")]
        public int ProductionPlanPatilID { get; set; }

        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("LotNoNum")]
        public byte LotNoNum { get; set; }

        [JsonProperty("LotNo")]
        public string LotNo { get; set; }

        [JsonProperty("PlannedCapacity")]
        public short PlannedCapacity { get; set; }
        #endregion Base properties

        [JsonProperty("ProductionPlan")]
        public ProductionPlansDTO ProductionPlan { get; set; }

        [JsonProperty("DataProductionLis")]
        public List<DataProductionDTO> DataProductionLis { get; set; }

        [JsonProperty("ProductionPlanReworksList")]
        public List<ProductionPlanReworksDTO> ProductionPlanReworksList { get; set; }


    }
}