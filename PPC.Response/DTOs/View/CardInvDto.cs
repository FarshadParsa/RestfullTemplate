using Newtonsoft.Json;
using System.Collections.Generic;
namespace WebApi.Response.DTOs
{
    public class CardInvDTO
    {

        #region Base properties
        [JsonProperty("InvTypeID")]
        public char InvTypeID { get; set; }

        [JsonProperty("Year")]
        public short Year { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }
        #endregion Base properties

    }
}