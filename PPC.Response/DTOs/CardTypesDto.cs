using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class CardTypesDTO
    {

        #region Base properties
        [JsonProperty("CardTypeID")]
        public byte CardTypeID { get; set; }

        [JsonProperty("CardTypeName")]
        public string CardTypeName { get; set; }

        [JsonProperty("CardTypeVal")]
        public string CardTypeVal { get; set; }

        [JsonProperty("OrderBy")]
        public byte OrderBy { get; set; }

        [JsonProperty("IsEntry")]
        public bool IsEntry { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        #endregion Base properties

    }
}
