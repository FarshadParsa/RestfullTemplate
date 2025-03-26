using Newtonsoft.Json;
namespace WebApi.Response.DTOs
{
    public class ExcelExportSettingDetailDTO
    {

        #region Base properties
        [JsonProperty("ExcelExportSettingDetailID")]
        public long ExcelExportSettingDetailID { get; set; }

        [JsonProperty("Priority")]
        public int Priority { get; set; }

        [JsonProperty("ExcelExportSettingID")]
        public int ExcelExportSettingID { get; set; }

        [JsonProperty("FieldName")]
        public string FieldName { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Visible")]
        public bool Visible { get; set; }
        #endregion Base properties

        [JsonProperty("ExcelExportSetting")]
        public ExcelExportSettingDTO ExcelExportSetting { get; set; }

    }
}