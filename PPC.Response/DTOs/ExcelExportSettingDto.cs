using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApi.Response.DTOs
{
    public class ExcelExportSettingDTO
    {

        #region Base properties
        [JsonProperty("ExcelExportSettingID")]
        public int ExcelExportSettingID { get; set; }

        [JsonProperty("FormButtonName")]
        public string FormButtonName { get; set; }

        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("ConcatDateTimeToFileName")]
        public bool ConcatDateTimeToFileName { get; set; }

        [JsonProperty("UserID")]
        public int UserID { get; set; }
        #endregion Base properties


        [JsonProperty("ExcelExportSettingDetailList")]
        public List<ExcelExportSettingDetailDTO> ExcelExportSettingDetailList { get; set; }

    }
}