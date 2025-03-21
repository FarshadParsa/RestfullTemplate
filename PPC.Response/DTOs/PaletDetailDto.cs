using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class PaletDetailDTO
    {

        #region Base properties
        [JsonProperty("PaletDetailID")]
        public int PaletDetailID { get; set; }

        [JsonProperty("InvProductID")]
        public int InvProductID { get; set; }

        [JsonProperty("PaletID")]
        public int PaletID { get; set; }
        #endregion Base properties


        [JsonProperty("InvProduct")]
        public InvProductsDTO InvProduct { get; set; }

        [JsonProperty("Palet")]
        public PaletsDTO Palet { get; set; }


    }
}