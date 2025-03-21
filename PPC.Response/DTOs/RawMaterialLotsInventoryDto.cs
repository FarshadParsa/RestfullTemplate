using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class RawMaterialLotsInventoryDTO
    {

        #region Base properties
        [JsonProperty("LotNo")]
        public string LotNo { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("ExpireDate")]
        public string ExpireDate { get; set; }

        [JsonProperty("NetWeight")]
        public decimal NetWeight { get; set; }

        [JsonProperty("DeliveredAmount")]
        public decimal DeliveredAmount { get; set; }

        [JsonProperty("RemainingWeight")]
        public decimal RemainingWeight { get; set; }
        #endregion Base properties


        [JsonProperty("RawMaterial")]
        public RawMaterialsDTO RawMaterial { get; set; }

    }
}