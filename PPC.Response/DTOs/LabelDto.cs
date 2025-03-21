using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class LabelDTO
    {

        #region Base properties
        [JsonProperty("LabelID")]
        public int LabelID { get; set; }

        [JsonProperty("LabelName")]
        public string LabelName { get; set; }

        [JsonProperty("ZebraCommand")]
        public string ZebraCommand { get; set; }
        #endregion Base properties
    }
}