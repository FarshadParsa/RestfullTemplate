using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class InvTypesDTO
    {

        #region Base properties
        [JsonProperty("InvTypeID")]
        public char InvTypeID { get; set; }

        [JsonProperty("InvTypeName")]
        public string InvTypeName { get; set; }

        [JsonProperty("OrderBy")]
        public byte OrderBy { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        #endregion Base properties

    }
}