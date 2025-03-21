using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Response.DTOs
{
    public class WeightingProductDetailDTO
    {

        #region Base properties
        [JsonProperty("WeightingProductDetailID")]
        public int WeightingProductDetailID { get; set; }

        [JsonProperty("WeightingProductID")]
        public int WeightingProductID { get; set; }

        [JsonProperty("PackagingPlanID")]
        public int PackagingPlanID { get; set; }

        [JsonProperty("QTY")]
        public short QTY { get; set; }

        [JsonProperty("EmptyWeight")]
        public decimal EmptyWeight { get; set; }

        [JsonProperty("NetWeight")]
        public decimal NetWeight { get; set; }
        #endregion Base properties


        [JsonProperty("WeightingProduct")]
        public WeightingProductsDTO WeightingProduct { get; set; }

        [JsonProperty("PackagingPlan")]
        public PackagingPlansDTO PackagingPlan { get; set; }


        [JsonProperty("InvProductList")]
        public List<InvProductsDTO> InvProductList { get; set; }



    }
}