using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class CustomerDraftPaletsDTO
    {

        #region Base properties
        [JsonProperty("CustomerDraftPaletID")]
        public int CustomerDraftPaletID { get; set; }

        [JsonProperty("CustomerDraftID")]
        public int CustomerDraftID { get; set; }

        [JsonProperty("PaletID")]
        public int PaletID { get; set; }
        #endregion Base properties


        [JsonProperty("CustomerDraft")]
        public CustomerDraftsDTO CustomerDraft { get; set; }

        [JsonProperty("Palet")]
        public PaletsDTO Palet { get; set; }

    }
}