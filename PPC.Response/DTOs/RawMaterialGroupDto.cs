using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class RawMaterialGroupsDTO
    {

        [JsonProperty("RawMaterialGroupID")]
        public int RawMaterialGroupID { get; set; }

        [JsonProperty("RawMaterialGroupName")]
        public string RawMaterialGroupName { get; set; }

        [JsonProperty("RawMaterialGroupLatinName")]
        public string RawMaterialGroupLatinName { get; set; }

        [JsonProperty("IsRecycled")]
        public bool IsRecycled { get; set; }

        [JsonProperty("IsLiquid")]
        public bool IsLiquid { get; set; }

        [JsonProperty("StorageConditions")]
        public string StorageConditions { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

    }
}
