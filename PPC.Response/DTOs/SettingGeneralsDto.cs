using Newtonsoft.Json;
namespace WebApi.Response.DTOs
{
    public class SettingGeneralsDTO
    {

        #region Base properties and methods(generated by  CodeGenerator)
        [JsonProperty("SettingGeneralID")]
        public int SettingGeneralID { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("FactoryNameEn")]
        public string FactoryNameEn { get; set; }

        [JsonProperty("FactoryNameFa")]
        public string FactoryNameFa { get; set; }

        [JsonProperty("CalendarCultureInfo")]
        public string CalendarCultureInfo { get; set; }

        [JsonProperty("CurrencyDecimalSeparator")]
        public string CurrencyDecimalSeparator { get; set; }

        [JsonProperty("ReportCustomerDraftFormCode")]
        public string ReportCustomerDraftFormCode { get; set; }

        [JsonProperty("LogOpeningForm")]
        public bool LogOpeningForm { get; set; }

        [JsonProperty("LogClosingForm")]
        public bool LogClosingForm { get; set; }

        [JsonProperty("LogButtonsClick")]
        public bool LogButtonsClick { get; set; }

        [JsonProperty("FactoryCode")]
        public byte FactoryCode { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)

    }
}